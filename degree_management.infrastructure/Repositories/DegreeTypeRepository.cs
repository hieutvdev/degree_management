using AutoMapper;
using degree_management.application.Dtos.Responses.DegreeType;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.constracts.RepositoryBase.EntityFramework;

public class DegreeTypeRepository (IRepositoryBase<DegreeType> repositoryBase, IMapper mapper) : IDegreeTypeRepository
{
    public async Task<bool> CreateDegreeTypeAsync(DegreeType degreeTypeModel)
    {
        await repositoryBase.AddAsync(degreeTypeModel);
        var isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> UpdateDegreeTypeAsync(DegreeType degreeTypeModel)
    {
        await repositoryBase.UpdateAsync(t => t.Id == degreeTypeModel.Id, degreeTypeModel);
        var isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<PaginatedResult<DegreeTypeDto>> GetListDegreeTypesAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default)
    {
        var result = await repositoryBase.GetPageAsync(paginationRequest, cancellationToken);
        var data = mapper.Map<IEnumerable<DegreeType>, IEnumerable<DegreeTypeDto>>(result.Data).ToList();
        return new PaginatedResult<DegreeTypeDto>(data: data, pageSize: paginationRequest.PageSize,
            pageIndex: paginationRequest.PageIndex, count: data.Count());
    }
}