namespace degree_management.application.Dtos.Requests.Major;

public record CreateMajorRequest(string Name, string Code, bool Active, string Description, int FacultyId);