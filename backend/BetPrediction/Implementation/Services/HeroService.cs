using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using AutoMapper;
using CsvHelper;
using Implementation.OpenDotaApi.Models.Responses;
using Models.Hero;
using Repositories;
using Repositories.Models.Entities;
using Services;

namespace Implementation.Services;

public class HeroService : IHeroServices
{
    private readonly IHeroRepository _heroRepository;
    private readonly IMapper _mapper;
    private readonly HttpClient _openDotaHttpClient;
    private readonly IPickBanRepository _pickBanRepository;

    public HeroService(IHttpClientFactory httpClientFactory, IHeroRepository heroRepository, IMapper mapper,
        IPickBanRepository pickBanRepository)
    {
        _openDotaHttpClient = httpClientFactory.CreateClient(Constants.OpenDotaApiHttpClientName);
        _heroRepository = heroRepository;
        _mapper = mapper;
        _pickBanRepository = pickBanRepository;
    }

    public async Task LoadHeroesToSystem()
    {
        var dbHeroes = await _heroRepository.GetHeroesAsync();
        var dbHeroesIdList = dbHeroes.Select(hero => hero.OpenDotaId).ToList();
        var openDotaHeroesStringResponse = await _openDotaHttpClient.GetStringAsync("constants/heroes");
        var jsonResponse = JsonNode.Parse(openDotaHeroesStringResponse).AsObject();
        var heroesData = jsonResponse.Select(x => x.Value.Deserialize<HeroData>()).ToList();
        var newHeroList = new List<HeroEntity>();

        foreach (var hero in heroesData)
            if (!dbHeroesIdList.Contains(hero.OpenDotaId))
                newHeroList.Add(_mapper.Map<HeroEntity>(hero));

        if (newHeroList.Any()) await _heroRepository.SaveHeroesAsync(newHeroList);
    }

    public async Task<string> GenerateHeroMatrixForPeriod(DateOnly startPeriodDate, DateOnly endPeriodDate)
    {
        var pickBans = await _pickBanRepository.GetPickBansForPeriod(startPeriodDate, endPeriodDate);
        return await GenerateHeroMatrix(pickBans);
    }

    public async Task GenerateDataForPickBansPredictionModelTraining(DateOnly startPeriodDate, DateOnly endPeriodDate,
        double testSize)
    {
        var pickBans = await _pickBanRepository.GetPickBansForPeriod(startPeriodDate, endPeriodDate);
        var trainAndTestLists = SplitEntitiesForTrainAndTestList(pickBans, testSize);
        await GenerateHeroMatrix(trainAndTestLists.Item1);
        await GeneratePickBansDataSet("train_pick_bans", trainAndTestLists.Item1);
        await GeneratePickBansDataSet("test_pick_bans", trainAndTestLists.Item2);
    }

    public async Task<string> GeneratePickBansDataSetForPeriod(DateOnly startPeriodDate, DateOnly endPeriodDate,
        string dataSetName)
    {
        var pickBans = await _pickBanRepository.GetPickBansForPeriod(startPeriodDate, endPeriodDate);
        return await GeneratePickBansDataSet(dataSetName, pickBans);
    }

    private Tuple<List<PickBanEntity>, List<PickBanEntity>> SplitEntitiesForTrainAndTestList(
        List<PickBanEntity> entities,
        double testSize)
    {
        var pickBansByGames = entities
            .GroupBy(x => x.GameId);
        var countOfTestListPickBans = entities.Count * testSize;
        var testList = new List<PickBanEntity>(Convert.ToInt32(countOfTestListPickBans));

        while (testList.Count <= countOfTestListPickBans)
        {
            testList.AddRange(pickBansByGames.First());
            pickBansByGames = pickBansByGames.Skip(1);
        }

        var trainList = pickBansByGames
            .SelectMany(x=>x)
            .ToList();

        return new Tuple<List<PickBanEntity>, List<PickBanEntity>>(trainList, testList);
    }

    private async Task<string> GenerateHeroMatrix(List<PickBanEntity> pickBans)
    {
        var picksByGames = pickBans
            .Where(x => x.IsPick)
            .GroupBy(x => x.GameId);

        var heroes = await _heroRepository.GetHeroesAsync();
        var heroMatrixRows = heroes.ToDictionary(
            x => x.OpenDotaId,
            x => new HeroMatrixRow
            {
                HeroId = x.OpenDotaId,
                HeroName = x.LocalizedName,
                TotalGamesCount = pickBans.Count(y => y.OpenDotaHeroId == x.OpenDotaId),
                WinGamesCount = pickBans.Count(y => y.OpenDotaHeroId == x.OpenDotaId && y.Win),
                PicksCount = pickBans.Count(y => y.OpenDotaHeroId == x.OpenDotaId && y.IsPick),
                BansCount = pickBans.Count(y => y.OpenDotaHeroId == x.OpenDotaId && !y.IsPick),
                WinRateOppositeHeroes = heroes.ToDictionary(y => y.OpenDotaId, y => new WinRateOppositeHero
                {
                    GamesOppositeHeroCount = 0, OppositeHeroId = y.OpenDotaId, OppositeHeroName = y.LocalizedName,
                    WinsOppositeHeroCount = 0
                })
            });
        foreach (var group in picksByGames)
        {
            if (group.Count() != 10)
            {
                continue;
            }
            foreach (var pickBan in group)
            foreach (var oppositeHero in group)
            {
                if (oppositeHero.OpenDotaHeroId == pickBan.OpenDotaHeroId) continue;


                if (pickBan.RadiantTeam != oppositeHero.RadiantTeam)
                {
                    heroMatrixRows[pickBan.OpenDotaHeroId].WinRateOppositeHeroes[oppositeHero.OpenDotaHeroId]
                        .GamesOppositeHeroCount++;
                    if (pickBan.Win)
                        heroMatrixRows[pickBan.OpenDotaHeroId].WinRateOppositeHeroes[oppositeHero.OpenDotaHeroId]
                            .WinsOppositeHeroCount++;
                }

                if (pickBan.RadiantTeam != oppositeHero.RadiantTeam)
                {
                    heroMatrixRows[oppositeHero.OpenDotaHeroId].WinRateOppositeHeroes[pickBan.OpenDotaHeroId]
                        .GamesOppositeHeroCount++;

                    if (oppositeHero.Win)
                        heroMatrixRows[oppositeHero.OpenDotaHeroId].WinRateOppositeHeroes[pickBan.OpenDotaHeroId]
                            .WinsOppositeHeroCount++;
                }
            }
        }
        

        using (var writer = new StreamWriter("HeroMatrix.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteHeader<HeroMatrixRow>();
            foreach (var oppositeHero in heroMatrixRows.Values.First().WinRateOppositeHeroes.Values)
                csv.WriteField(oppositeHero.OppositeHeroId);

            await csv.NextRecordAsync();

            foreach (var row in heroMatrixRows.Values)
            {
                csv.WriteRecord(row);
                foreach (var oppositeHero in row.WinRateOppositeHeroes.Values)
                    if (oppositeHero.GamesOppositeHeroCount != 0)
                        csv.WriteField(
                            (double)oppositeHero.WinsOppositeHeroCount / oppositeHero.GamesOppositeHeroCount);
                    else
                        csv.WriteField("NaN");
                await csv.NextRecordAsync();
            }
        }

        return "";
    }

    private static async Task<string> GeneratePickBansDataSet(string dataSetName, List<PickBanEntity> pickBans)
    {
        var pickBansByGames = pickBans
            .GroupBy(x => x.GameId);

        await using var writer = new StreamWriter($"{dataSetName}.csv");
        await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteHeader<PickBansDataSetRow>();
        var radiantFieldsHeaders = new[]
            { "r_b1", "r_b2", "r_b3", "r_b4", "r_b5", "r_b6", "r_b7", "r_p1", "r_p2", "r_p3", "r_p4", "r_p5" };
        var direFieldsHeaders = new[]
            { "d_b1", "d_b2", "d_b3", "d_b4", "d_b5", "d_b6", "d_b7", "d_p1", "d_p2", "d_p3", "d_p4", "d_p5" };
        foreach (var radiantHeader in radiantFieldsHeaders) csv.WriteField(radiantHeader);
        foreach (var direHeader in direFieldsHeaders) csv.WriteField(direHeader);
        await csv.NextRecordAsync();
        foreach (var group in pickBansByGames)
        {
            if (group.Count() != 24)
            {
                continue;
            }
            var row = new PickBansDataSetRow
            {
                GameId = group.First().GameId,
                RadiantWin = group.First(x => x.RadiantTeam).Win,
                RadiantPicks = group.Where(x => x.IsPick && x.RadiantTeam).Select(x => x.OpenDotaHeroId).ToList(),
                RadiantBans = group.Where(x => !x.IsPick && x.RadiantTeam).Select(x => x.OpenDotaHeroId).ToList(),
                DirePicks = group.Where(x => x.IsPick && !x.RadiantTeam).Select(x => x.OpenDotaHeroId).ToList(),
                DireBans = group.Where(x => !x.IsPick && !x.RadiantTeam).Select(x => x.OpenDotaHeroId).ToList()
            };

            csv.WriteRecord(row);
            foreach (var radiantBan in row.RadiantBans) csv.WriteField(radiantBan);
            foreach (var radiantPick in row.RadiantPicks) csv.WriteField(radiantPick);
            foreach (var direBan in row.DireBans) csv.WriteField(direBan);
            foreach (var direPick in row.DirePicks) csv.WriteField(direPick);
            await csv.NextRecordAsync();
        }

        return "";
    }
}