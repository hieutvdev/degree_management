namespace degree_management.application.Dtos.Requests.DegreeType;

public record UpdateDegreeTypeRequest(int Id, string Code, string Name, bool Active, float Duration, int Level, string Description);