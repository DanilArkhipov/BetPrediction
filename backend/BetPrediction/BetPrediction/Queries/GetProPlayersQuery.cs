using Common.Queries;

namespace BetPrediction.Queries;

public class GetProPlayersQuery: IQuery
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}