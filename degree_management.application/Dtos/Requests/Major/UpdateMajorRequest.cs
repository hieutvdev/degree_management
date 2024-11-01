namespace degree_management.application.Dtos.Requests.Major;

public record UpdateMajorRequest(int Id, string Name, string Code, bool Active, string? Description, int FacultyId);