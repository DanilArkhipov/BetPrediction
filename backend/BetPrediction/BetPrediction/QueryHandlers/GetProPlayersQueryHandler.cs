using BetPrediction.Models;
using BetPrediction.Models.Dto;
using BetPrediction.Queries;
using Common.Queries;
using Implementation.Data;
using Microsoft.EntityFrameworkCore;

namespace BetPrediction.QueryHandlers;

public class GetProPlayersQueryHandler: IQueryHandler<GetProPlayersQuery, BaseListModel<ProPlayerDto>>
{
    private readonly DataBaseContext _context;

    public GetProPlayersQueryHandler(DataBaseContext context)
    {
        _context = context;
    }

    private string GetRole(string role)
    {
        if (role.ToLower() == "support" || role is "4" or "5")
        {
            return "Поддержка";
        }
        if (role.ToLower() == "core" || role is "1" or "2" or "3")
        {
            return "Основа";
        }

        return "Нет данных";
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
            var matchesCount = rnd.Next(1200,2000);
            var wins = rnd.Next(1200);
            return new ProPlayerDto()
            {
                AvatarUrl = "https://dota2.ru/img/esport/player/433.png?1681041365",
                Id = x.Id,
                LossesCount = matchesCount - wins,
                MatchesCount = matchesCount,
                Name = string.IsNullOrEmpty(x.Name) ? "Нет данных" : x.Name,
                TeamName = string.IsNullOrEmpty(x.TeamName) ? "Свободный агент" : x.TeamName,
                Prizes = rnd.Next(100000),
                Region = string.IsNullOrEmpty(x.CountryCode) ? "Нет данных" : x.CountryCode.ToUpper(),
                Role = string.IsNullOrEmpty(x.FantasyRole) ? "Нет данных" : GetRole(x.FantasyRole),
                WinsCount = wins,
            };
        }).ToList();

        return new BaseListModel<ProPlayerDto>()
        {
            Items = playerDtos,
            TotalItemsCount = totalPlayersCount, 
        };


    }
}