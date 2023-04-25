namespace Implementation.Parsers.Models.Match;

public record MatchesListItem
{
    public string LeagueName { get; init; }
    
    public string FirstTeamName { get; init; }
    
    public string SecondTeamName { get; init; }
    
    public string Result { get; init; }
    
    public string MatchUrl { get; init; }
    
    public DateOnly Date { get; init; }
}