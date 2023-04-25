namespace Repositories.Models.Entities;

public class GameEntity: BaseEntity<Guid>
{
    public long MatchId { get; init; }
    
    public int? Cluster { get; init; }
    
    public long? GameDuration { get; init; }
    
    public int? Engine { get; init; }
    
    public int? GameMode { get; init; }
    
    public long? LeagueId { get; init; }
    
    public int? LobbyType { get; init; }
    
    public long? MatchSeqNum { get; init; }
    
    public bool? RadiantWin { get; init; }
    
    public long? StartTime { get; init; }
    
    public int? Version { get; init; }
    
    public long? ReplaySalt { get; init; }
    
    public long? SeriesId { get; init; }
    
    public long? SeriesType { get; init; }
    
    public int? Skill { get; init; }
    
    public int? Patch { get; init; }
    
    public long? Region { get; init; }
    
    public string? ReplayUrl { get; init; }
    
    public long? RadiantTeamOpenDotaId { get; init; }
    
    public long? DireTeamOpenDotaId { get; init; }
}