using degree_management.constracts.CQRS;
using MediatR;

namespace degree_management.application.Dtos.Responses;

public record ResponseBase(object? Data, string Message = "", bool IsSuccess = true, object? Error = null);