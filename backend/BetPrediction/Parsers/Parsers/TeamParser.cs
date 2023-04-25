// using AngleSharp.Dom;
// using AngleSharp.Html.Dom;
// using AngleSharp.Html.Parser;
// using Parsers.Constants;
// using Parsers.Models;
// using Parsers.Utils;
//
// namespace Parsers.Parsers;
//
// /// <summary>
// /// Парсер команд
// /// </summary>
// public class TeamParser: IParser<ShortTeamInfoModel, BaseTableParserParams>
// {
//     public async Task<dynamic> Parse()
//     {
//         try
//         {
//             var client = new HttpClient();
//             var htmlSourceCode = await client.GetStringAsync(DataSourcesUrls.TeamsUrl);
//             
//             var parser = new HtmlParser();
//             var document = await parser.ParseDocumentAsync(htmlSourceCode);
//             var teamsTable = (IHtmlTableElement?)document.QuerySelector(".global-content__tabel-version-1");
//
//             var teamModels = new List<ShortTeamInfoModel>();
//             if (teamsTable == null)
//             {
//                 return teamModels;
//             }
//             
//             teamModels.AddRange(teamsTable
//                 .QuerySelectorAll<IHtmlTableRowElement>(".title")
//                 .Select(x=> new ShortTeamInfoModel()
//                     {
//                         //Name = x.Cells[2].TextContent.Trim()
//                     }));
//             return teamModels;
//         }
//         catch (HttpRequestException e)
//         {
//             Console.ForegroundColor = ConsoleColor.Red;
//             Console.WriteLine("\nException Caught!");
//             Console.WriteLine("Message :{0} ", e.Message);
//             return e;
//         }
//     }
//
//     public Task<BaseTableParsedData<ShortTeamInfoModel>> Parse(BaseTableParserParams parserParams)
//     {
//         throw new NotImplementedException();
//     }
// }