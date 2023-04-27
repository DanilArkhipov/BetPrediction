namespace Common.Queries;

public interface IQueryHandler<in TQuery, TResultData> where TQuery : IQuery
{
    Task<TResultData> ExecuteAsync(TQuery query);
}