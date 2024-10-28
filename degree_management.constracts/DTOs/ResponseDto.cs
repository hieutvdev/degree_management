namespace degree_management.constracts.DTOs;

public record ResponseDto(
    object? MetaData  = null,
    bool IsSuccess = true,
    string Message = "");