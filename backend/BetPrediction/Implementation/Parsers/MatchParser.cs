using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Implementation.Parsers.Models.Match;
using Parsers;

namespace Implementation.Parsers;

public class MatchParser : BaseParser<MatchInfo>
{
    public MatchParser(HttpClient client) : base(client)
    {
    }

    protected override MatchInfo TransformContentToParsedData(IHtmlDocument document)
    {
        var matchGameIdList = 
        document.QuerySelectorAll(".dota-match-id").Select(idElement => Convert.ToInt64(idElement.TextContent.Trim()));
        return new MatchInfo()
        {
            GameIdList = matchGameIdList,
        };
    }
}