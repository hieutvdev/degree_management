namespace degree_management.application.Dtos.Requests.StudentGraduated;

public record UpdateStudentGraduatedRequest(
    int Id,
    string FullName,
    DateTime DateOfBirth,
    string StudentCode,
    int SpecializationId,
    int PreiodId,
    string? BirthPlace,
    string? ClassName,
    string? Cohort,
    int? Status,
    bool Gender,
    DateTime GraduationYear,
    float GPA10,
    float GPA4,
    int Honors,
    string? ContactEmail,
    string? PhoneNumber);