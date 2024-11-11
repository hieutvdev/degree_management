namespace degree_management.application.Dtos.Faculty;

public record CreateFacultyRequest(string Name, string Code, bool Active, string? Description);