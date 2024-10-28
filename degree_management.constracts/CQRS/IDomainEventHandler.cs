using MediatR;

namespace degree_management.constracts.CQRS;

public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent  : IDomainEvent
{
    
}