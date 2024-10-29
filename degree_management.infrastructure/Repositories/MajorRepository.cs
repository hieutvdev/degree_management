using AutoMapper;
using degree_management.application.Dtos.Responses.Major;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.constracts.RepositoryBase.EntityFramework;

public class MajorRepository(IRepositoryBase<Major> repositoryBase, IMapper mapper) : IMajorRepository
{
    public async Task<bool> CreateMajorAsync(Major majorModel)
    {
        await repositoryBase.AddAsync(majorModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<PaginatedResult<MajorDto>> GetPageAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default)
    {
        var result = await repositoryBase.GetPageAsync(paginationRequest, cancellationToken);
        var data = mapper.Map<IEnumerable<Major>, IEnumerable<MajorDto>>(result.Data).ToList();
        return new PaginatedResult<MajorDto>(data: data, pageSize: paginationRequest.PageSize,
            pageIndex: paginationRequest.PageIndex, count: data.Count());
    }
}