namespace degree_management.application.Dtos.Responses.Auth;

public record UserResponseBase(string Id, string UserName, string FullName, string Email, int Status, string Avatar, DateTime? CreatedDate);