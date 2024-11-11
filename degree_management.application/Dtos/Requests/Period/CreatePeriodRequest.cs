namespace degree_management.application.Dtos.Requests.Period;

public record CreatePeriodRequest(
    string Name,
    DateTime? StartDate,
    DateTime? EndDate,
    bool Active,
    string? Description,
    int YearGraduationId);