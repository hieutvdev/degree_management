using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Period;
using degree_management.constracts.Pagination;

namespace degree_management.application.Repositories;

public interface IPeriodRepository
{
    Task<bool> CreateAsync(Period periodModel);
    Task<bool> UpdateAsync(Period periodModel);
    Task<bool> DeleteAsync(int id);
    Task<Period> GetByIdAsync(int id);

    Task<PaginatedResult<PeriodDto>> GetPageAsync(PaginationRequest paginationRequest,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<SelectDto>> GetSelectAsync();
}