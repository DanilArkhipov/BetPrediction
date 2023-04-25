using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace Parsers;

public abstract class BaseParser<TData>: IParser<TData, BaseParserParams>
{
    private readonly HttpClient _client;

    protected BaseParser(HttpClient client)
    {
        _client = client;
    }

    public async Task<TData> Parse(BaseParserParams parserParams)
    {
        var htmlSourceCode = await _client.GetStringAsync(parserParams.ParsingUrl);

        var parser = new HtmlParser();
        var document = await parser.ParseDocumentAsync(htmlSourceCode);
        return TransformContentToParsedData(document);
    }
    
    
    protected abstract TData TransformContentToParsedData(IHtmlDocument document);
}