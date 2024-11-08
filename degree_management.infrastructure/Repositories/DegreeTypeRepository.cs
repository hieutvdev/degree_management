using System.Linq.Expressions;
using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.DegreeType;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.infrastructure.Repositories;

public class DegreeTypeRepository (IRepositoryBase<DegreeType> repositoryBase, IRepositoryBase<StudentGraduated> studentRepo, IMapper mapper) : IDegreeTypeRepository
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

    public async Task<bool> DeleteDegreeTypeAsync(int degreeTypeId)
    {
        await repositoryBase.DeleteAsync(dt => dt.Id == degreeTypeId);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<DegreeType> GetDegreeTypeByIdAsync(int degreeTypeId)
    {
        var result = await repositoryBase.GetByFieldAsync("Id", degreeTypeId);
        return result;
    }

    public async Task<List<DegreeType>> GetDegreeTypesByStudentAsync(List<int> studentsId)
    {
        var students = await studentRepo.FindAsync(s => studentsId.Contains(s.Id));
        var specializationIds = students.Select(s => s.SpecializationId).ToList();
        var degreeTypes = await repositoryBase.FindAsync(dt => specializationIds.Contains(dt.SpecializationId));
        return degreeTypes.AsQueryable().ToList();
    }

    public async Task<PaginatedResult<DegreeTypeDto>> GetListDegreeTypesAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default)
    {
        var includes = new List<Expression<Func<DegreeType, object>>>
        {
            m => m.Specialization!
        };

        var result = await repositoryBase.GetPageWithIncludesAsync(
            paginationRequest,
            selector: m => new DegreeTypeDto
            {
                Id = m.Id,
                Code = m.Code,
                Name = m.Name,
                Duration = m.Duration,
                Descripion = m.Description,
                SpecializationName = m.Specialization!.Name 
            },
            includes: includes,
            cancellationToken: cancellationToken
        );

        return result;
    }

    public async Task<IEnumerable<SelectDto>> GetSelectDegreeTypesAsync()
    {
        var result = await repositoryBase.GetSelectAsync(selector: type =>  new SelectDto {Text = type.Name,Value = type.Id });
        return result;
    }
}