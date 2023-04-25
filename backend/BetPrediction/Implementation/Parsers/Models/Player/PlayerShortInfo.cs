namespace Parsers.Models.Player;

public class PlayerShortInfo
{
    /// <summary>
    /// Никнейм
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Команда
    /// </summary>
    public string Team { get; set; }
    
    /// <summary>
    /// Регион
    /// </summary>
    public string Region { get; set; }
    
    /// <summary>
    /// Призовые
    /// </summary>
    public string TotalPrize { get; set; }
    
    /// <summary>
    /// Матчи
    /// </summary>
    public string MatchesCount { get; set; }
}