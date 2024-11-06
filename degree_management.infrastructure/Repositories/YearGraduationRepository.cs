using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Faculty;
using degree_management.application.Dtos.Responses.YearGraduation;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.infrastructure.Repositories;

public class YearGraduationRepository(IRepositoryBase<YearGraduation> repositoryBase, IMapper mapper)
    : IYearGraduationRepository
{
    public async Task<bool> CreateAsync(YearGraduation yearGraduationModel)
    {
        await repositoryBase.AddAsync(yearGraduationModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> UpdateAsync(YearGraduation yearGraduationModel)
    {
        await repositoryBase.UpdateAsync(r => r.Id == yearGraduationModel.Id, yearGraduationModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await repositoryBase.DeleteAsync(r => r.Id == id);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<YearGraduation> GetByIdAsync(int id)
    {
        var result = await repositoryBase.GetByFieldAsync("Id", id);
        return result;
    }

    public async Task<PaginatedResult<YearGraduationDto>> GetPageAsync(PaginationRequest paginationRequest,
        CancellationToken cancellationToken = default)
    {
        var result = await repositoryBase.GetPageAsync(paginationRequest, cancellationToken);
        var data = mapper.Map<IEnumerable<YearGraduation>, IEnumerable<YearGraduationDto>>(result.Data).ToList();
        return new PaginatedResult<YearGraduationDto>(data: data, pageSize: paginationRequest.PageSize,
            pageIndex: paginationRequest.PageIndex, count: data.Count());
    }

    public async Task<IEnumerable<SelectDto>> GetSelectAsync()
    {
        var result = await repositoryBase.GetSelectAsync(
            selector: yearGraduation => new SelectDto { Text = yearGraduation.Name ?? "", Value = yearGraduation.Id },
            conditions: yearGraduation => (yearGraduation.Active ?? false));
        return result;
    }
}