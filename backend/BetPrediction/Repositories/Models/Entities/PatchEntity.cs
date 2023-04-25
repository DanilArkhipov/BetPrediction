namespace Repositories.Models.Entities;

public class PatchEntity: BaseEntity<Guid>
{
    public string Name { get; set; }
    
    public DateTime Date { get; set; }
    
    public int OpenDotaId { get; set; }
}