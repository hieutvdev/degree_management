using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.StudentGraduated;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.constracts.RepositoryBase.EntityFramework;

public class StudentGraduatedRepository(IRepositoryBase<StudentGraduated> repositoryBase, IMapper mapper)
    : IStudentGraduatedRepository
{
    public async Task<bool> CreateStudentGraduatedAsync(StudentGraduated studentGraduatedModel)
    {
        await repositoryBase.AddAsync(studentGraduatedModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> UpdateStudentGraduatedAsync(StudentGraduated studentGraduatedModel)
    {
        await repositoryBase.UpdateAsync(s => s.Id == studentGraduatedModel.Id, studentGraduatedModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> DeleteStudentGraduatedAsync(int degreeTypeId)
    {
        await repositoryBase.DeleteAsync(s => s.Id == degreeTypeId);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<StudentGraduated> GetStudentGraduatedByIdAsync(int degreeTypeId)
    {
        var result = await repositoryBase.GetByFieldAsync("Id", degreeTypeId);
        return result;
    }

    public async Task<PaginatedResult<StudentGraduatedDto>> GetListStudentGraduatedsAsync(
        PaginationRequest paginationRequest, CancellationToken cancellationToken = default)
    {
        var result = await repositoryBase.GetPageAsync(paginationRequest, cancellationToken);
        var data = mapper.Map<IEnumerable<StudentGraduated>, IEnumerable<StudentGraduatedDto>>(result.Data).ToList();
        return new PaginatedResult<StudentGraduatedDto>(data: data, pageSize: paginationRequest.PageSize,
            pageIndex: paginationRequest.PageIndex, count: data.Count());
    }

    public async Task<IEnumerable<SelectDto>> GetSelectStudentGraduatedsAsync()
    {
        var result = await repositoryBase.GetSelectAsync(selector: graduated => new SelectDto {Text = graduated.FullName,Value = graduated.Id },
            conditions: s => s.MajorId != 0);
        return result;
    }
}