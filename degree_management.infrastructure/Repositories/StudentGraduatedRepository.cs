using System.Linq.Expressions;
using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.StudentGraduated;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.constracts.Specifications;
using degree_management.domain.Entities;
using degree_management.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace degree_management.infrastructure.Repositories;

public class StudentGraduatedRepository
    : IStudentGraduatedRepository
{
    private readonly IRepositoryBase<StudentGraduated> _repositoryBase;
    private readonly IMapper _mapper;
    private readonly DbSet<StudentGraduated> _dbSet;

    public StudentGraduatedRepository(
        IRepositoryBase<StudentGraduated> repositoryBase,
        IMapper mapper,
        ApplicationDbContext dbContext)
    {
        _repositoryBase = repositoryBase;
        _mapper = mapper;
        _dbSet = dbContext.Set<StudentGraduated>();
    }

    public async Task<bool> CreateStudentGraduatedAsync(StudentGraduated studentGraduatedModel)
    {
        await _repositoryBase.AddAsync(studentGraduatedModel);
        bool isSuccess = await _repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> CreateStudentGraduatedsAsync(IEnumerable<StudentGraduated> studentGraduatedsModel)
    {
        await _repositoryBase.AddRangeAsync(studentGraduatedsModel);
        bool isSuccess = await _repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> UpdateStudentGraduatedAsync(StudentGraduated studentGraduatedModel)
    {
        await _repositoryBase.UpdateAsync(s => s.Id == studentGraduatedModel.Id, studentGraduatedModel);
        bool isSuccess = await _repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> DeleteStudentGraduatedAsync(int studentGraduatedId)
    {
        await _repositoryBase.DeleteAsync(s => s.Id == studentGraduatedId);
        bool isSuccess = await _repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }


    public async Task<StudentGraduated> GetStudentGraduatedByIdAsync(int studentGraduatedId)
    {
        var result = await _repositoryBase.GetByFieldAsync("Id", studentGraduatedId);
        return result;
    }

    public async Task<PaginatedResult<StudentGraduatedDto>> GetListStudentGraduatedsAsync(
        SearchBaseModel searchBase, CancellationToken cancellationToken = default)
    {
        var query = _dbSet?.AsQueryable()
            .Select(s => new StudentGraduatedDto
            {
                Id = s.Id,
                StudentCode = s.StudentCode,
                FullName = s.FullName,
                DateOfBirth = s.DateOfBirth,
                Gender = s.Gender,
                GraduationYear = s.GraduationYear,
                PeriodId = s.PeriodId,
                PeriodName = s.Period!.Name,
                GPA10 = s.GPA10,
                GPA4 = s.GPA4,
                Honors = s.Honors,
                BirthPlace = s.BirthPlace,
                ClassName = s.ClassName,
                Cohort = s.Cohort,
                Status = s.Status,
                ContactEmail = s.ContactEmail,
                PhoneNumber = s.PhoneNumber,
            });

        if (query != null)
        {
            var students = await query.ToListAsync(cancellationToken: cancellationToken);
            if (!string.IsNullOrEmpty(searchBase.KeySearch))
            {
                var keySearch = searchBase.KeySearch.ToLower();
                students = (List<StudentGraduatedDto>)students.Where(s =>
                    s.StudentCode.ToLower().Contains(keySearch) || s.FullName.ToLower().Contains(keySearch) ||
                    s.ClassName!.ToLower().Contains(keySearch)).ToList();
            }

            if (!string.IsNullOrEmpty(searchBase.SortBy))
            {
                var sortBy = QueryableExtensions.GetProperty<StudentGraduatedDto>(searchBase.SortBy);
                students = searchBase.IsOrder == true
                    ? students.OrderBy(sortBy).ToList()
                    : students.OrderByDescending(sortBy).ToList();
            }
            else
            {
                students = students.OrderByDescending(r => r.FullName).ToList();
            }

            int pageIndex = searchBase.PageIndex ?? 1;
            int pageSize = searchBase.PageSize ?? 20;
            return new PaginatedResult<StudentGraduatedDto>(
                pageIndex,
                pageSize,
                students.Count,
                students.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
            );
        }

        return null!;
    }

    public async Task<IEnumerable<SelectDto>> GetSelectStudentGraduatedsAsync()
    {
        var result = await _repositoryBase.GetSelectAsync(
            selector: graduated => new SelectDto { Text = graduated.FullName, Value = graduated.Id },
            conditions: s => s.PeriodId != 0);
        return result;
    }
}