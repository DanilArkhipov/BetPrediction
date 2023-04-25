using System.Text.Json;
using System.Text.Json.Nodes;
using AutoMapper;
using Implementation.OpenDotaApi.Models.Responses;
using Repositories;
using Repositories.Models.Entities;
using Services;

namespace Implementation.Services;

public class HeroService: IHeroServices
{
    private readonly HttpClient _openDotaHttpClient;
    private readonly IHeroRepository _heroRepository;
    private readonly IMapper _mapper;

    public HeroService(IHttpClientFactory httpClientFactory, IHeroRepository heroRepository, IMapper mapper)
    {
        _openDotaHttpClient = httpClientFactory.CreateClient(Constants.OpenDotaApiHttpClientName);
        _heroRepository = heroRepository;
        _mapper = mapper;
    }

    public async Task LoadHeroesToSystem()
    {
        var dbHeroes = await _heroRepository.GetHeroesAsync();
        var dbHeroesIdList = dbHeroes.Select(hero => hero.OpenDotaId).ToList();
        var openDotaHeroesStringResponse = await _openDotaHttpClient.GetStringAsync("constants/heroes");
        var jsonResponse = JsonObject.Parse(openDotaHeroesStringResponse).AsObject();
        var heroesData = jsonResponse.Select(x => x.Value.Deserialize<HeroData>()).ToList();
        var newHeroList = new List<HeroEntity>();
        
        foreach (var hero in heroesData)
        {
            if (!dbHeroesIdList.Contains(hero.OpenDotaId))
            {
                newHeroList.Add(_mapper.Map<HeroEntity>(hero));
            }
        }

        if (newHeroList.Any())
        {
            await _heroRepository.SaveHeroesAsync(newHeroList);
        }
    }
}