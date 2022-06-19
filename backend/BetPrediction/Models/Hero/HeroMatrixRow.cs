namespace Models.Hero;

public class HeroMatrixRow
{
    public int HeroId { get; set; }
    
    public string HeroName { get; set; }
    
    public Dictionary<int,WinRateOppositeHero> WinRateOppositeHeroes { get; set; }
    
    public int TotalGamesCount { get; set; }
    
    public int PicksCount { get; set; }
    
    public int BansCount { get; set; }
    
    public int WinGamesCount { get; set; }
}