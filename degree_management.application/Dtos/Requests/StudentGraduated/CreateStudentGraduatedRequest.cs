namespace degree_management.application.Dtos.Requests.StudentGraduated;

public record CreateStudentGraduatedRequest(
    string FullName,
    DateTime DateOfBirth,
    string StudentCode,
    int MajorId,
    int PeriodId,
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

public record BulkCreateStudentGraduatedRequest(
    List<CreateStudentGraduatedRequest> Students
);