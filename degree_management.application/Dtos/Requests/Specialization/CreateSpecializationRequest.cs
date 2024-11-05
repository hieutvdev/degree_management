namespace degree_management.application.Dtos.Requests.Specialization;

public record CreateSpecializationRequest(string Name, string Code, bool Active, string? Description, int MajorId);