using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.application.Repositories;

public interface IFacultyRepository
{
    Task<bool> CreateAsync(Faculty facultyModel);
    Task<bool> UpdateAsync(Faculty facultyModel);
    Task<bool> DeleteAsync(int id);
    Task<Faculty> GetByIdAsync(int id);
    Task<PaginatedResult<Faculty>> GetPageAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default);
}