namespace Repositories.Models.Entities;

public class LeagueEntity: BaseEntity<Guid>
{
    public string Name { get; set; }
    
    public long LeagueId { get; set; }
    
    public string Tier { get; set; }
}