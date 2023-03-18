using System.Collections;

namespace Parsers;

public interface IPaginatedParser<TData, in TParserParams>
{
    public IAsyncEnumerable<BaseTableParsedData<TData>> Parse(TParserParams? parserParams = default);
}