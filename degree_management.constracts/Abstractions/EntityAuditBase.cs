using degree_management.constracts.Abstractions.Entities;

namespace degree_management.constracts.Abstractions;

public class EntityAuditBase<T> : EntityBase<T>, IEntityAuditBase<T>
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}