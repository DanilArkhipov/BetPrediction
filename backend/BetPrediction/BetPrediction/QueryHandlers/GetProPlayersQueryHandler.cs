using BetPrediction.Models;
using BetPrediction.Models.Dto;
using BetPrediction.Queries;
using Common.Queries;
using Implementation.Data;
using Microsoft.EntityFrameworkCore;

namespace BetPrediction.QueryHandlers;

public class GetProPlayersQueryHandler : IQueryHandler<GetProPlayersQuery, BaseListModel<ProPlayerDto>>
{
    private readonly DataBaseContext _context;

    public GetProPlayersQueryHandler(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<BaseListModel<ProPlayerDto>> ExecuteAsync(GetProPlayersQuery query)
    {
        var rnd = new Random();
        var playerEntities = await _context.Players
            .OrderBy(x => x.Id)
            .Skip(query.Page * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
        var totalPlayersCount = await _context.Players.CountAsync();
        var playerDtos = playerEntities.Select(x =>
        {
            var wins = rnd.Next(x.MatchesCount);
            return new ProPlayerDto
            {
                AvatarUrl = x.ProfessionalAvatarUrl.Replace("about://", "https://dota2.ru"),
                Id = x.Id,
                LossesCount = x.MatchesCount - wins,
                MatchesCount = x.MatchesCount,
                Name = string.IsNullOrEmpty(x.Name) ? "Нет данных" : x.Name,
                TeamName = string.IsNullOrEmpty(x.TeamName) ? "Свободный агент" : x.TeamName,
                Prizes = x.TotalPrizesInDollars,
                Region = string.IsNullOrEmpty(x.CountryCode) ? "Нет данных" : x.CountryCode.ToUpper(),
                Role = string.IsNullOrEmpty(x.FantasyRole) ? "Нет данных" : GetRole(x.FantasyRole),
                WinsCount = wins
            };
        }).ToList();

        return new BaseListModel<ProPlayerDto>
        {
            Items = playerDtos,
            TotalItemsCount = totalPlayersCount
        };
    }

    private string GetRole(string role)
    {
        if (role.ToLower() == "support" || role is "4" or "5") return "Поддержка";
        if (role.ToLower() == "core" || role is "1" or "2" or "3") return "Основа";

        return "Нет данных";
    }
}