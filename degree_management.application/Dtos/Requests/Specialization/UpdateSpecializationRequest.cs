namespace degree_management.application.Dtos.Requests.Specialization;

public record UpdateSpecializationRequest(
    int Id,
    string Name,
    string Code,
    bool Active,
    string? Description,
    int MajorId);