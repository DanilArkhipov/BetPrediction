using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Parsers;
using Parsers.Constants;
using Parsers.Models.Player;

namespace Implementation.Parsers;


// Парсер игроков
public class PlayerShortInfoParser: BasePaginatedTableParser<PlayerShortInfo>
{

    protected override BaseTableParsedData<PlayerShortInfo> TransformTableContentToParsedData(IHtmlTableElement tableElement)
    {
        var players = new List<PlayerShortInfo>();
        var rows = tableElement.QuerySelectorAll<IHtmlTableRowElement>("tr").Skip(1);
        foreach (var row in rows)
        {
            var player = new PlayerShortInfo();
            var cells = row.Cells;
                
            player.Name = cells[0].TextContent.Trim();
            player.Team = cells[1].TextContent.Trim();
            player.Region = cells[2].TextContent.Trim();
            player.TotalPrize = cells[3].TextContent.Trim();
            player.MatchesCount = cells[4].TextContent.Trim();
                
            players.Add(player);
        }

        return new BaseTableParsedData<PlayerShortInfo>(players);
    }

    protected override string ParsingUrl => DataSourcesUrls.PlayersListUrl;
    
    protected override string TableSelector => ".global-content__tabel-version-1";
}