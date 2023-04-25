namespace Implementation.Parsers.Models.Match;

public record MatchInfo
{
    public IEnumerable<long> GameIdList { get; init; }
}