using System.Linq.Expressions;
using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Major;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.infrastructure.Repositories;

public class MajorRepository(IRepositoryBase<Major> repositoryBase, IMapper mapper) : IMajorRepository
{
    public async Task<bool> CreateMajorAsync(Major majorModel)
    {
        await repositoryBase.AddAsync(majorModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> UpdateMajorAsync(Major majorModel)
    {
        await repositoryBase.UpdateAsync(m => m.Id == majorModel.Id,majorModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> DeleteMajorAsync(int majorId)
    {
        await repositoryBase.DeleteAsync(m => m.Id == majorId);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<MajorDto> GetMajorByIdAsync(int majorId)
    {
        var includes = new List<Expression<Func<Major, object>>>
        {
            m => m.Faculty!
        };
        
        var result = await repositoryBase.GetByFieldWithIncludesAsync("Id", majorId, includes: includes);
        var majorDto = mapper.Map<MajorDto>(result);
        return majorDto;
    }

    public async Task<PaginatedResult<MajorDto>> GetPageAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default)
    {
  
        var includes = new List<Expression<Func<Major, object>>>
        {
            m => m.Faculty!
        };

        var result = await repositoryBase.GetPageWithIncludesAsync(
            paginationRequest,
            selector: m => new MajorDto
            {
                Id = m.Id,
                Code = m.Code,
                Name = m.Name,
                Description = m.Description,
                FacultyId = m.FacultyId,
                FacultyName = m.Faculty!.Name 
            },
            includes: includes,
            cancellationToken: cancellationToken
        );

        return result;
    }

    public async Task<IEnumerable<SelectDto>> GetSelectAsync()
    {
        var result = await repositoryBase.GetSelectAsync(selector: major => new SelectDto {Text = major.Name,Value = major.Id });
        return result;
    }
}