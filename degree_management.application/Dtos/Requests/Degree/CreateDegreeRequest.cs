namespace degree_management.application.Dtos.Requests.Degree;

public record CreateDegreeRequest(
    int StundentId,
    int DegreeTypeId,
    string Code,
    string RegNo,
    DateTime IssueDate,
    int Status,
    string? Description);