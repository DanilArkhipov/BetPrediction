using Common.Queries;

namespace BetPrediction.Queries;

public class GetAdminLogsQuery : IQuery
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}