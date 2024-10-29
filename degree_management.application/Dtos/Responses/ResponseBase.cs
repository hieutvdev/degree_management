namespace degree_management.application.Dtos.Responses;

public record ResponseBase(object? Data, string Message = "", bool IsSuccess = true);