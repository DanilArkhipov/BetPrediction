namespace Parsers;

public interface IParser<TData, in TParserParams>
{
    public Task<TData> Parse(TParserParams? parserParams = default);
}