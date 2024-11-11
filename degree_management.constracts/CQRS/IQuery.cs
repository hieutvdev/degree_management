using MediatR;

namespace degree_management.constracts.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
    
}