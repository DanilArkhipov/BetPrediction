using System.Collections;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace Parsers;

public abstract class BasePaginatedTableParser<TData> : IPaginatedParser<TData, BaseTableParserParams>
{
    private int _currentPage;
    private int _pagesCount;
    private readonly HttpClient _client;

    protected BasePaginatedTableParser()
    {
        _currentPage = 1;
        _pagesCount = 1;
        _client = new HttpClient();
    }

    public async IAsyncEnumerable<BaseTableParsedData<TData>> Parse(BaseTableParserParams? parserParams = default)
    {
        yield return await _ParseAsync(setPagesCount: true);

        while (_currentPage < _pagesCount)
        {
            _currentPage++;
            yield return await _ParseAsync();
        }
    }

    private async Task<BaseTableParsedData<TData>> _ParseAsync(bool setPagesCount = false,
        BaseTableParserParams? parserParams = default)
    {
        try
        {
            var htmlSourceCode = await _client.GetStringAsync(GetPageUrl());

            var parser = new HtmlParser();
            var document = await parser.ParseDocumentAsync(htmlSourceCode);
            var table = (IHtmlTableElement?)document.QuerySelector(TableSelector);
            if (setPagesCount)
            {
                _pagesCount = Convert.ToInt32(document.QuerySelectorAll(".pagination__link--right")
                    .First().TextContent.Trim());
            }

            if (table == null)
            {
                return new BaseTableParsedData<TData>(new List<TData>());
            }

            return TransformTableContentToParsedData(table);
        }
        catch (HttpRequestException e)
        {
            return new BaseTableParsedData<TData>(errorMessage: e.Message);
        }
    }

    private string GetPageUrl()
    {
        return $"{ParsingUrl}?page={_currentPage}";
    }

    protected abstract BaseTableParsedData<TData> TransformTableContentToParsedData(IHtmlTableElement tableElement);

    protected abstract string TableSelector { get; }
    protected abstract string ParsingUrl { get; }
}