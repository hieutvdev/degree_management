namespace degree_management.constracts.Abstractions.Entities;

public interface IEntityAuditBase<T> : IEntityBase<T>, IAuditable
{
    
}