namespace degree_management.application.Dtos.Responses.Auth;

public record LoginResponseDto(UserDto UserDto, string Token);