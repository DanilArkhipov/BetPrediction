using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Models.Entities;

public class HeroEntity: BaseEntity<Guid>
{
    public int OpenDotaId { get; init; }
    
    public string Name { get; init; }
    
    public string LocalizedName { get; init; }

    public string OpenDotaRelativeHeroImageUrl { get; init; }
    
    public string OpenDotaRelativeHeroIconUrl { get; init; }
}