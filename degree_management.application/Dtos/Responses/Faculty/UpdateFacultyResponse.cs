namespace degree_management.application.Dtos.Responses.Faculty;

public record UpdateFacultyResponse(int Id, string Name, string Code, bool Active, string Description);