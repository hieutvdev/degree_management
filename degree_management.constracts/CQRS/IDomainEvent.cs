using MediatR;

namespace degree_management.constracts.CQRS;

public interface IDomainEvent : INotification
{
    public Guid IdEvent { get; init; }
}