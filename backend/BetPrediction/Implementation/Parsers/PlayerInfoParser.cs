using System.Globalization;
using AngleSharp.Html.Dom;
using Parsers;
using Parsers.Constants;
using Parsers.Models.Player;
using Repositories.Models.Enums;

namespace Implementation.Parsers;

public class PlayerInfoParser : BaseParser<PlayerFullInfo?>
{

    public PlayerInfoParser(HttpClient client) : base(client)
    {
    }
    
    protected override PlayerFullInfo? TransformContentToParsedData(IHtmlDocument document)
    {
        try
        {
            var playerRoleString =
                document.QuerySelector("#playerPosition").TextContent.Trim();
            var playerBirthDateString =
                document.QuerySelector("#playerBirthday").TextContent.Trim();
            var socialLinks = document.QuerySelector(".cybersport-players-player__social").QuerySelectorAll("a").Select(x=> x as IHtmlAnchorElement);
            var steamProfile = socialLinks.Single(x => x.Title == "Steam").Href;
            var playerProfessionalAvatar = document
                .QuerySelector(".cybersport-players-player")
                .GetElementsByTagName("img")
                .Select(x => (x as IHtmlImageElement).Source)
                .FirstOrDefault();
            return new PlayerFullInfo()
            {
                BirthDate = playerBirthDateString,
                Role = playerRoleString,
                SteamProfileUrl = steamProfile,
                PlayerProfessionalAvatar = new Uri(new Uri(DataSourcesUrls.Dota2RuUrl), playerProfessionalAvatar).AbsoluteUri,
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}