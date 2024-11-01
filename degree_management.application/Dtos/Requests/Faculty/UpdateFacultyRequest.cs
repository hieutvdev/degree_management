namespace degree_management.application.Dtos.Faculty;

public record UpdateFacultyRequest(int Id, string Name, string Code, bool Active, string? Description);