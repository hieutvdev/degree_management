using System.Linq.Expressions;
using AutoMapper;
using degree_management.application.Dtos.Requests.Degree;
using degree_management.application.Dtos.Requests.Inventory;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Degree;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.infrastructure.Repositories;

public class DegreeRepository(
    IRepositoryBase<Degree> repositoryBase,
    IDegreeTypeRepository degreeTypeRepo,
    IInventoryRepository inventoryRepo,
    IMapper mapper) : IDegreeRepository
{
    public async Task<bool> CreateDegreeAsync(Degree degreeModel)
    {
        await repositoryBase.AddAsync(degreeModel);
        var isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> UpdateDegreeAsync(Degree degreeModel)
    {
        await repositoryBase.UpdateAsync(t => t.Id == degreeModel.Id, degreeModel);
        var isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> DeleteDegreeAsync(int degreeId)
    {
        await repositoryBase.DeleteAsync(dt => dt.Id == degreeId);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> IssueIdentificationNumAsync(IssueIdentificationNumRequest request)
    {
        var degreeTypes = await degreeTypeRepo.GetDegreeTypesByStudentAsync(request.StudentIds);


        var groupedRequests = degreeTypes
            .GroupBy(degreeType => degreeType.Id)
            .Select(group => new StockOutRequest(
                WarehouseId: request.WarehouseId,
                DegreeTypeId: group.Key,
                Quantity: group.Count(),
                Description: request.SuffixCode
            ))
            .ToList();


        var issueIdentificationDetails = new List<Degree>();
        int currentCodeNum = request.StartCodeNum;
        int currentRegNoNum = request.StartRegNoNum;

        foreach (var studentId in request.StudentIds)
        {
            string code = string.Format("{0}{1:D" + request.CodeLength + "}", request.PrefixCode, currentCodeNum);
            string regNo = string.Format("{0}{1:D" + request.RegNoLength + "}", request.PrefixRegNo,
                currentRegNoNum);


            var issueDetail = new Degree
            {
                StudentGraduatedId = studentId,
                Code = code,
                RegNo = regNo,
                IssueDate = DateTime.Now,
                Status = 1,
                Description = request.SuffixCode ?? string.Empty
            };


            issueIdentificationDetails.Add(issueDetail);


            currentCodeNum++;
            currentRegNoNum++;
        }

        var resultStockOut = await inventoryRepo.StockOutAsync(groupedRequests);

        await repositoryBase.AddRangeAsync(issueIdentificationDetails);

        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;

        return isSuccess && resultStockOut;
    }


    public async Task<Degree> GetDegreeByIdAsync(int degreeId)
    {
        var result = await repositoryBase.GetByFieldAsync("Id", degreeId);
        return result;
    }

    public async Task<PaginatedResult<DegreeDto>> GetListDegreesAsync(PaginationRequest paginationRequest,
        CancellationToken cancellationToken = default)
    {
        
        var includes = new List<Expression<Func<Degree, object>>>
        {
            m => m.StudentGraduated!
        };

        var result = await repositoryBase.GetPageWithIncludesAsync(
            paginationRequest,
            selector: m => new DegreeDto()
            {
                Id = m.Id,
                StundentCode = m.StudentGraduated!.StudentCode,
                StudentName = m.StudentGraduated.FullName,
                Code = m.Code,
                RegNo = m.RegNo,
                Status = m.Status,
                Description = m.Description,
            },
            includes: includes,
            cancellationToken: cancellationToken
        );

        return result;
    }

    public async Task<IEnumerable<SelectDto>> GetSelectDegreesAsync()
    {
        var result = await repositoryBase.GetSelectAsync(
            selector: type => new SelectDto { Text = type.Code, Value = type.Id },
            conditions: d => d.StudentGraduatedId != 0);
        return result;
    }
}