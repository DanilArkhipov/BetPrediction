namespace Repositories.Models.Entities;

public class BaseEntity<TKey>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public TKey Id { get; init; }
}