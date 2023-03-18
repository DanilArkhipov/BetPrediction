namespace Parsers;

public interface IParser<TData, in TParserParams>
{
    public Task<BaseTableParsedData<TData>> Parse(TParserParams? parserParams = default);
}