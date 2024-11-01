namespace degree_management.application.Dtos.Requests.StudentGraduated;

public record UpdateStudentGraduatedRequest(int Id, string FullName,
    DateTime DateOfBirth,
    bool Gender,
    DateTime GraduationYear,
    int MajorId,
    float GPA,
    int Honors,
    string? ContactEmail,
    string? PhoneNumber);