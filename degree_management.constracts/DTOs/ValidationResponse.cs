namespace degree_management.constracts.DTOs;

public record ValidationResponse(object? Data, string Message = "", bool IsSuccess = true, object? Error = null);