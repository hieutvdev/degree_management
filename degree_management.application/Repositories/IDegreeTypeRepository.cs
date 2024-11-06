using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.DegreeType;
using degree_management.constracts.Pagination;

namespace degree_management.application.Repositories;

public interface IDegreeTypeRepository
{
    Task<bool> CreateDegreeTypeAsync(DegreeType degreeTypeModel);
    Task<bool> UpdateDegreeTypeAsync(DegreeType degreeTypeModel);
    Task<bool> DeleteDegreeTypeAsync(int degreeTypeId);
    Task<DegreeType> GetDegreeTypeByIdAsync(int degreeTypeId);
    Task<List<DegreeType>> GetDegreeTypesByStudentAsync(List<int> studentsId);

    Task<PaginatedResult<DegreeTypeDto>> GetListDegreeTypesAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default);
    Task<IEnumerable<SelectDto>> GetSelectDegreeTypesAsync();
}