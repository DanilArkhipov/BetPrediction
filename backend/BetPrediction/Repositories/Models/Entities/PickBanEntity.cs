namespace Repositories.Models.Entities;

public class PickBanEntity: BaseEntity<Guid>
{
    public bool IsPick { get; init; }
    
    public int OpenDotaHeroId { get; init; }
    
    public bool RadiantTeam { get; init; }
    
    public long GameId { get; init; }
    
    public bool Win { get; init; }
}