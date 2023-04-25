namespace Models.Entities;

public class BaseEntity<TKey>
{
    public TKey Id { get; private set; }
}