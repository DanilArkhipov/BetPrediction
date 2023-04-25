using System.Globalization;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Implementation.Parsers.Models.Match;
using Parsers;
using Parsers.Constants;

namespace Implementation.Parsers;

public class MatchesListParser : BasePaginatedParser<MatchesListItem>
{
    protected override string ParsingUrl => DataSourcesUrls.MatchesListUrl;

    protected override BaseTableParsedData<MatchesListItem> TransformContentToParsedData(IElement tableElement)
    {
        var matches = new List<MatchesListItem>();
        var rows = tableElement.QuerySelectorAll(".list-match-item");
        foreach (var row in rows)
        {
            try
            {
                var rawDate = row.QuerySelector(".time_block_desktop")?.TextContent.Trim();
                DateOnly? date;
                if (rawDate == null)
                {
                   continue;
                }

                date = GetDateByRussianString(rawDate);
                if( date == null)
                {
                    continue;
                }

                matches.Add(new MatchesListItem()
                {
                    LeagueName = row.QuerySelector("img").GetAttribute("data-title-tooltipe"),
                    FirstTeamName =
                        row.QuerySelectorAll(".cybersport-matches__matches-name").First().TextContent.Trim(),
                    SecondTeamName =
                        row.QuerySelectorAll(".cybersport-matches__matches-name").Last().TextContent.Trim(),
                    Result = row.QuerySelector(".score").GetAttribute("data-value"),
                    MatchUrl = new Uri(new Uri(DataSourcesUrls.Dota2RuUrl),
                        row.QuerySelector(".cybersport-matches__matches-match-wrap ").GetAttribute("href")).ToString(),
                    Date = date.Value
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        {
        }
        return new BaseTableParsedData<MatchesListItem>(matches);
    }

    protected override string TableSelector => ".past-matches-list";

    private DateOnly GetDateByRussianString(string dateTimeString)
    {
        if (dateTimeString.Contains("назад"))
        {
            return DateOnly.FromDateTime(DateTime.Now);
        }

        var dateOnlyString = ConvertDateStringToCorrectFormat(dateTimeString);
        
        
        DateTime parsedDateTime;
        DateTime.TryParseExact(dateOnlyString, "dd.MM.yyyy", CultureInfo.GetCultureInfo("ru-RU"),
            DateTimeStyles.None, out parsedDateTime);
        return DateOnly.FromDateTime(parsedDateTime);
    }

    private string ConvertDateStringToCorrectFormat(string dateTimeString)
    {
        var dateOnlyString = dateTimeString.Substring(0, dateTimeString.Length - 6);
        if (dateOnlyString.Contains("Янв"))
        {
            dateOnlyString = dateOnlyString.Replace(" Янв ", ".01.");
        }
        
        if (dateOnlyString.Contains("Фев"))
        {
            dateOnlyString = dateOnlyString.Replace(" Фев ", ".02.");
        }
        
        if (dateOnlyString.Contains("Мар"))
        {
            dateOnlyString = dateOnlyString.Replace(" Мар ", ".03.");
        }
        
        if (dateOnlyString.Contains("Апр"))
        {
            dateOnlyString = dateOnlyString.Replace(" Апр ", ".04.");
        }
        
        if (dateOnlyString.Contains("Май"))
        {
            dateOnlyString = dateOnlyString.Replace(" Май ", ".05.");
        }
        
        if (dateOnlyString.Contains("Июн"))
        {
            dateOnlyString = dateOnlyString.Replace(" Июн ", ".06.");
        }
        
        if (dateOnlyString.Contains("Июл"))
        {
            dateOnlyString = dateOnlyString.Replace(" Июл ", ".07.");
        }
        
        if (dateOnlyString.Contains("Авг"))
        {
            dateOnlyString = dateOnlyString.Replace(" Авг ", ".08.");
        }
     
        if (dateOnlyString.Contains("Сен"))
        {
            dateOnlyString = dateOnlyString.Replace(" Сен ", ".09.");
        }
        
        if (dateOnlyString.Contains("Окт"))
        {
            dateOnlyString = dateOnlyString.Replace(" Окт ", ".10.");
        }
        
        if (dateOnlyString.Contains("Ноя"))
        {
            dateOnlyString = dateOnlyString.Replace(" Ноя ", ".11.");
        }
        
        if (dateOnlyString.Contains("Дек"))
        {
            dateOnlyString = dateOnlyString.Replace(" Дек ", ".12.");
        }
        return dateOnlyString;
    }
}