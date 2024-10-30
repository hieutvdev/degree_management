using System.Linq.Expressions;
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
        var includes = new List<Expression<Func<StudentGraduated, object>>>
        {
            m => m.Major!
        };
        var result = await repositoryBase.GetPageWithIncludesAsync(paginationRequest,selector: s => new StudentGraduatedDto
        {
            Id = s.Id,
            FullName = s.FullName,
            DateOfBirth = s.DateOfBirth,
            Gender = s.Gender,
            GraduationYear = s.GraduationYear,
            MajorId = s.MajorId,
            MajorName = s.Major!.Name,
            GPA = s.GPA,
            Honors = s.Honors,
            ContactEmail = s.ContactEmail,
            PhoneNumber = s.PhoneNumber,
        }, cancellationToken: cancellationToken);
       
        return result;
    }

    public async Task<IEnumerable<SelectDto>> GetSelectStudentGraduatedsAsync()
    {
        var result = await repositoryBase.GetSelectAsync(selector: graduated => new SelectDto {Text = graduated.FullName,Value = graduated.Id },
            conditions: s => s.MajorId != 0);
        return result;
    }
}