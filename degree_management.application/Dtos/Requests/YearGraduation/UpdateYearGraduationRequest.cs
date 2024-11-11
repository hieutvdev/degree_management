namespace degree_management.application.Dtos.Requests.YearGraduation;

public record UpdateYearGraduationRequest(int Id, string Name, bool Active, string? Description);