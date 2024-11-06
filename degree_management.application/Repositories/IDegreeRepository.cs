using degree_management.application.Dtos.Requests.Degree;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Degree;
using degree_management.constracts.Pagination;

namespace degree_management.application.Repositories;

public interface IDegreeRepository
{
    Task<bool> CreateDegreeAsync(Degree degreeModel);
    Task<bool> UpdateDegreeAsync(Degree degreeModel);
    Task<bool> DeleteDegreeAsync(int degreeId);
    Task<bool> IssueIdentificationNumAsync(IssueIdentificationNumRequest request);
    Task<Degree> GetDegreeByIdAsync(int degreeId);
    Task<PaginatedResult<DegreeDto>> GetListDegreesAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default);
    Task<IEnumerable<SelectDto>> GetSelectDegreesAsync();
}