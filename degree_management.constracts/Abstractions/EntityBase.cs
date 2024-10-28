using degree_management.constracts.Abstractions.Entities;

namespace degree_management.constracts.Abstractions;

public abstract class EntityBase<T> : IEntityBase<T>
{
    protected EntityBase()
    {
        if (typeof(T) == typeof(Guid))
        {
            Id = (T)(object)Guid.NewGuid();
        }else if (typeof(T) == typeof(int))
        {
            Id = (T)(object)0;
        }
    }
    
    public T Id { get; set; }
}