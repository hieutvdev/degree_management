using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Faculty;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.application.Repositories;

public interface IFacultyRepository
{
    Task<bool> CreateAsync(Faculty facultyModel);
    Task<bool> UpdateAsync(Faculty facultyModel);
    Task<bool> DeleteAsync(int id);
    Task<Faculty> GetByIdAsync(int id);
    Task<PaginatedResult<FacultyDto>> GetPageAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default);
    Task<IEnumerable<SelectDto>> GetSelectAsync();
}