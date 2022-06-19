namespace Models.Hero;

public class PickBansDataSetRow
{
    public long GameId { get; set; }
    
    public bool RadiantWin { get; set; }

    public List<int> RadiantBans { get; set; }
    
    public List<int> RadiantPicks { get; set; }
    
    public List<int> DireBans { get; set; }
    
    public List<int> DirePicks { get; set; }
}