namespace Repositories.Models.Entities;

public class UpdatableEntity<TKey>: BaseEntity<TKey>
{
    public DateTime LastUpdateTime { get; set; }
}