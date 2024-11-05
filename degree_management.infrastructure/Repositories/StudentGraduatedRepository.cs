using System.Linq.Expressions;
using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.StudentGraduated;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.infrastructure.Repositories;

public class StudentGraduatedRepository(IRepositoryBase<StudentGraduated> repositoryBase, IMapper mapper)
    : IStudentGraduatedRepository
{
    public async Task<bool> CreateStudentGraduatedAsync(StudentGraduated studentGraduatedModel)
    {
        await repositoryBase.AddAsync(studentGraduatedModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> CreateStudentGraduatedsAsync(IEnumerable<StudentGraduated> studentGraduatedsModel)
    {
       await repositoryBase.AddRangeAsync(studentGraduatedsModel);
       bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
       return isSuccess;
    }

    public async Task<bool> UpdateStudentGraduatedAsync(StudentGraduated studentGraduatedModel)
    {
        await repositoryBase.UpdateAsync(s => s.Id == studentGraduatedModel.Id, studentGraduatedModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> DeleteStudentGraduatedAsync(int studentGraduatedId)
    {
        await repositoryBase.DeleteAsync(s => s.Id == studentGraduatedId);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<StudentGraduated> GetStudentGraduatedByIdAsync(int studentGraduatedId)
    {
        var result = await repositoryBase.GetByFieldAsync("Id", studentGraduatedId);
        return result;
    }

    public async Task<PaginatedResult<StudentGraduatedDto>> GetListStudentGraduatedsAsync(
        PaginationRequest paginationRequest, CancellationToken cancellationToken = default)
    {
        var includes = new List<Expression<Func<StudentGraduated, object>>>
        {
            m => m.Specialization!
        };
        var result = await repositoryBase.GetPageWithIncludesAsync(paginationRequest,selector: s => new StudentGraduatedDto
        {
            Id = s.Id,
            FullName = s.FullName,
            DateOfBirth = s.DateOfBirth,
            Gender = s.Gender,
            GraduationYear = s.GraduationYear,
            SpecializationId = s.SpecializationId,
            SpecializationName = s.Specialization!.Name,
            GPA10 = s.GPA10,
            GPA4 = s.GPA4,
            Honors = s.Honors,
            ContactEmail = s.ContactEmail,
            PhoneNumber = s.PhoneNumber,
        }, cancellationToken: cancellationToken);
       
        return result;
    }

    public async Task<IEnumerable<SelectDto>> GetSelectStudentGraduatedsAsync()
    {
        var result = await repositoryBase.GetSelectAsync(selector: graduated => new SelectDto {Text = graduated.FullName,Value = graduated.Id },
            conditions: s => s.SpecializationId != 0);
        return result;
    }
}