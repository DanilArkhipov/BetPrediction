using BetPrediction.Models;
using BetPrediction.Models.Dto;
using BetPrediction.Queries;
using Common.Queries;
using Implementation.Data;
using Microsoft.EntityFrameworkCore;

namespace BetPrediction.QueryHandlers;

public class GetAdminLogsQueryHandler : IQueryHandler<GetAdminLogsQuery, BaseListModel<AdminLogsDto>>
{
    private readonly DataBaseContext _context;

    public GetAdminLogsQueryHandler(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<BaseListModel<AdminLogsDto>> ExecuteAsync(GetAdminLogsQuery query)
    {
        var logs = await _context.AdminLogs
            .OrderBy(x => x.StartDate)
            .Skip(query.Page * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
        var totalLogsCount = await _context.AdminLogs.CountAsync();

        return new BaseListModel<AdminLogsDto>
        {
            Items = logs.Select(x => new AdminLogsDto
            {
                ActionName = x.ActionName,
                Id = x.Id.ToString(),
                StartDate = x.StartDate,
                UserName = x.UserName,
                Period = $"{x.StartPeriodDate.ToShortDateString()}-{x.EndPeriodDate.ToShortDateString()}"
            }).ToList(),
            TotalItemsCount = totalLogsCount
        };
    }
}