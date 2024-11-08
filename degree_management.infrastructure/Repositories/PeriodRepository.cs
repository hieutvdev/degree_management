using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Period;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.infrastructure.Repositories;

public class PeriodRepository(IRepositoryBase<Period> repositoryBase, IMapper mapper) : IPeriodRepository
{
    public async Task<bool> CreateAsync(Period periodModel)
    {
        await repositoryBase.AddAsync(periodModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> UpdateAsync(Period periodModel)
    {
        await repositoryBase.UpdateAsync(r => r.Id == periodModel.Id, periodModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await repositoryBase.DeleteAsync(r => r.Id == id);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<Period> GetByIdAsync(int id)
    {
        var result = await repositoryBase.GetByFieldAsync("Id", id);
        return result;
    }

    public async Task<PaginatedResult<PeriodDto>> GetPageAsync(PaginationRequest paginationRequest,
        CancellationToken cancellationToken = default)
    {
        var result = await repositoryBase.GetPageAsync(paginationRequest, cancellationToken);
        var data = mapper.Map<IEnumerable<Period>, IEnumerable<PeriodDto>>(result.Data).ToList();
        return new PaginatedResult<PeriodDto>(data: data, pageSize: paginationRequest.PageSize,
            pageIndex: paginationRequest.PageIndex, count: data.Count());
    }

    public async Task<IEnumerable<SelectDto>> GetSelectAsync()
    {
        var result = await repositoryBase.GetSelectAsync(selector: period => new SelectDto {Text = period.Name ?? "",Value = period.Id });
        return result;
    }
}