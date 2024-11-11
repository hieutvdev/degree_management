namespace degree_management.application.Dtos.Requests.YearGraduation;

public record CreateYearGraduationRequest(string Name, bool Active, string? Description);