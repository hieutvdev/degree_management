namespace degree_management.constracts.Abstractions.Entities;

public interface IEntityBase<T>
{
    T Id { get; set; }
}