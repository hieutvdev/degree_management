using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Specialization;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.infrastructure.Repositories;

public class SpecializationRepository(IRepositoryBase<Specialization> repositoryBase, IMapper mapper) : ISpecializationRepository
{
    public async Task<bool> CreateAsync(Specialization specializationModel)
    {
        await repositoryBase.AddAsync(specializationModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> UpdateAsync(Specialization specializationModel)
    {
        await repositoryBase.UpdateAsync(r => r.Id == specializationModel.Id, specializationModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await repositoryBase.DeleteAsync(r => r.Id == id);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<Specialization> GetByIdAsync(int id)
    {
        var result = await repositoryBase.GetByFieldAsync("Id", id);
        return result;
    }

    public async Task<PaginatedResult<SpecializationDto>> GetPageAsync(PaginationRequest paginationRequest,
        CancellationToken cancellationToken = default)
    {
        var result = await repositoryBase.GetPageAsync(paginationRequest, cancellationToken);
        var data = mapper.Map<IEnumerable<Specialization>, IEnumerable<SpecializationDto>>(result.Data).ToList();
        return new PaginatedResult<SpecializationDto>(data: data, pageSize: paginationRequest.PageSize,
            pageIndex: paginationRequest.PageIndex, count: data.Count());
    }

    public async Task<IEnumerable<SelectDto>> GetSelectAsync()
    {
        var result = await repositoryBase.GetSelectAsync(selector: specialization => new SelectDto {Text = specialization.Name,Value = specialization.Id });
        return result;
    }
}