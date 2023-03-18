namespace Repositories.Models.Entities;

public class TeamEntity: UpdatableEntity<Guid>
{
    public int TeamId { get; init; }
    
    public double TeamRating { get; init; }
    
    public int TotalWins { get; init; }
    
    public int TotalLosses { get; init; }
    
    public int LastMatchTimeStamp { get; init; }
    
    public string TeamName { get; init; }
    
    public string TeamTag { get; init; }
    
    public ICollection<PlayerEntity> TeamMembers { get; set; }
}