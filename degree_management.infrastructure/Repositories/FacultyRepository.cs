using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Faculty;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.constracts.RepositoryBase.EntityFramework;

public class FacultyRepository(IRepositoryBase<Faculty> repositoryBase, IMapper mapper) : IFacultyRepository
{
    public async Task<bool> CreateAsync(Faculty facultyModel)
    {
        await repositoryBase.AddAsync(facultyModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> UpdateAsync(Faculty facultyModel)
    {
        await repositoryBase.UpdateAsync(r => r.Id == facultyModel.Id, facultyModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await repositoryBase.DeleteAsync(r => r.Id == id);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<Faculty> GetByIdAsync(int id)
    {
        var result = await repositoryBase.GetByFieldAsync("Id", id);
        return result;
    }

    public async Task<PaginatedResult<FacultyDto>> GetPageAsync(PaginationRequest paginationRequest,
        CancellationToken cancellationToken = default)
    {
        var result = await repositoryBase.GetPageAsync(paginationRequest, cancellationToken);
        var data = mapper.Map<IEnumerable<Faculty>, IEnumerable<FacultyDto>>(result.Data).ToList();
        return new PaginatedResult<FacultyDto>(data: data, pageSize: paginationRequest.PageSize,
            pageIndex: paginationRequest.PageIndex, count: data.Count());
    }

    public async Task<IEnumerable<SelectDto>> GetSelectAsync()
    {
        var result = await repositoryBase.GetSelectAsync(selector: faculty => new SelectDto {Text = faculty.Name,Value = faculty.Id });
        return result;
    }
}