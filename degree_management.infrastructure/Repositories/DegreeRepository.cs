using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Degree;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.infrastructure.Repositories;

public class DegreeRepository(IRepositoryBase<Degree> repositoryBase, IMapper mapper) : IDegreeRepository
{
    public async Task<bool> CreateDegreeAsync(Degree degreeModel)
    {
        await repositoryBase.AddAsync(degreeModel);
        var isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> UpdateDegreeAsync(Degree degreeModel)
    {
        await repositoryBase.UpdateAsync(t => t.Id == degreeModel.Id, degreeModel);
        var isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> DeleteDegreeAsync(int degreeId)
    {
        await repositoryBase.DeleteAsync(dt => dt.Id == degreeId);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<Degree> GetDegreeByIdAsync(int degreeId)
    {
        var result = await repositoryBase.GetByFieldAsync("Id", degreeId);
        return result;
    }

    public async Task<PaginatedResult<DegreeDto>> GetListDegreesAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default)
    {
        var result = await repositoryBase.GetPageAsync(paginationRequest, cancellationToken);
        var data = mapper.Map<IEnumerable<Degree>, IEnumerable<DegreeDto>>(result.Data).ToList();
        return new PaginatedResult<DegreeDto>(data: data, pageSize: paginationRequest.PageSize,
            pageIndex: paginationRequest.PageIndex, count: data.Count());
    }

    public async Task<IEnumerable<SelectDto>> GetSelectDegreesAsync()
    {
        var result = await repositoryBase.GetSelectAsync(selector: type =>  new SelectDto {Text = type.Code,Value = type.Id },
            conditions: d => d.StundentId != 0 && d.DegreeTypeId != 0);
        return result;
    }
}