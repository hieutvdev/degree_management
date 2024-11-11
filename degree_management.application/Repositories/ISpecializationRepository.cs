using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Faculty;
using degree_management.application.Dtos.Responses.Specialization;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.application.Repositories;

public interface ISpecializationRepository
{
    Task<bool> CreateAsync(Specialization specializationModel);
    Task<bool> UpdateAsync(Specialization specializationModel);
    Task<bool> DeleteAsync(int id);
    Task<Specialization> GetByIdAsync(int id);
    Task<PaginatedResult<SpecializationDto>> GetPageAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default);
    Task<IEnumerable<SelectDto>> GetSelectAsync();
}