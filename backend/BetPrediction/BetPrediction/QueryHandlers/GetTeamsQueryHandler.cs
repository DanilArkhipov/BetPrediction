using BetPrediction.Models;
using BetPrediction.Models.Dto;
using BetPrediction.Queries;
using Common.Queries;
using Implementation.Data;
using Microsoft.EntityFrameworkCore;

namespace BetPrediction.QueryHandlers;

public class GetTeamsQueryHandler : IQueryHandler<GetTeamsQuery, BaseListModel<TeamsDto>>
{
    private readonly DataBaseContext _context;

    public GetTeamsQueryHandler(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<BaseListModel<TeamsDto>> ExecuteAsync(GetTeamsQuery query)
    {
        var teamsEntities = await _context.Teams
            .OrderBy(x => x.Id)
            .Skip(query.Page * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
        var totalTeamsCount = await _context.Teams.CountAsync();
        var teamDtos = teamsEntities.Select(x => new TeamsDto()
        {
            TeamLogoUrl = "https://dota2.ru/img/esport/team/5801.png?1678643833",
            Id = x.Id,
            TeamName = x.TeamName,
            TeamTag = x.TeamTag,
            TotalLosses = x.TotalLosses.ToString(),
            TotalWins = x.TotalWins.ToString()
        }).ToList();

        return new BaseListModel<TeamsDto>()
        {
            Items = teamDtos,
            TotalItemsCount = totalTeamsCount,
        };


    }
}