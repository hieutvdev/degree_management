using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Faculty;
using degree_management.application.Dtos.Responses.YearGraduation;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.application.Repositories;

public interface IYearGraduationRepository
{
    Task<bool> CreateAsync(YearGraduation facultyModel);
    Task<bool> UpdateAsync(YearGraduation facultyModel);
    Task<bool> DeleteAsync(int id);
    Task<YearGraduation> GetByIdAsync(int id);
    Task<PaginatedResult<YearGraduationDto>> GetPageAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default);
    Task<IEnumerable<SelectDto>> GetSelectAsync();
}