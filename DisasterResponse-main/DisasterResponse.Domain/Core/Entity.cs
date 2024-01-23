namespace DisasterResponse.Domain.Core;

public class Entity<TKey> where TKey : IEquatable<TKey>
{
    protected Entity()
    {
        
    }

    protected Entity(TKey id) => Id = id;
    public TKey Id { get; protected set; }
}