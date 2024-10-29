namespace degree_management.application.Dtos.Responses;

public record ResponseBase(object? Metadata, string Message = "", bool IsSuccess = true);