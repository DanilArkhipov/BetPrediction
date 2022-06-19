using BetPrediction.Models.Dto;
using Common.Queries;
using Implementation.Data;
using Microsoft.EntityFrameworkCore;

namespace BetPrediction.QueryHandlers;

public class GetPredictionDataQueryHandler : IQueryHandler<GetPredictionDataQuery, PredictionDataDto>
{
    private readonly DataBaseContext _context;

    public GetPredictionDataQueryHandler(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<PredictionDataDto> ExecuteAsync(GetPredictionDataQuery query)
    {
        var players = await _context.Players.ToListAsync();
        var heroes = await _context.Heroes.ToListAsync();

        return new PredictionDataDto
        {
            Players = players.Select(x => new PlayerPredictionDataDto
                {
                    Id = x.AccountId.ToString(),
                    AvatarUrl = x.ProfessionalAvatarUrl.Replace("about://", "https://dota2.ru"),
                    Name = x.Name
                })
                .ToList(),
            Heroes = heroes.Select(x => new HeroPredictionDataDto
                {
                    Id = x.OpenDotaId.ToString(),
                    Name = x.LocalizedName
                })
                .ToList()
        };
    }
}