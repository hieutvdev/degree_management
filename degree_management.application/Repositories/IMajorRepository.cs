using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Major;
using degree_management.constracts.Pagination;

namespace degree_management.application.Repositories;

public interface IMajorRepository
{
    Task<bool> CreateMajorAsync(Major majorModel);
    Task<bool> UpdateMajorAsync(Major majorModel);
    Task<bool> DeleteMajorAsync(int majorId);
    Task<Major> GetMajorByIdAsync(int majorId);
    Task<PaginatedResult<MajorDto>> GetPageAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default);
    Task<IEnumerable<SelectDto>> GetSelectAsync();

}