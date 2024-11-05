using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.StudentGraduated;
using degree_management.constracts.Pagination;

namespace degree_management.application.Repositories;

public interface IStudentGraduatedRepository
{
    Task<bool> CreateStudentGraduatedAsync(StudentGraduated studentGraduatedModel);
    Task<bool> CreateStudentGraduatedsAsync(IEnumerable<StudentGraduated> studentGraduatedsModel);
    Task<bool> UpdateStudentGraduatedAsync(StudentGraduated studentGraduatedModel);
    Task<bool> DeleteStudentGraduatedAsync(int degreeTypeId);
    Task<StudentGraduated> GetStudentGraduatedByIdAsync(int degreeTypeId);
    Task<PaginatedResult<StudentGraduatedDto>> GetListStudentGraduatedsAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default);
    Task<IEnumerable<SelectDto>> GetSelectStudentGraduatedsAsync();
}
