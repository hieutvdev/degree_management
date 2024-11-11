using System.Linq.Expressions;
using AutoMapper;
using degree_management.application.Dtos.Requests.Inventory;
using degree_management.application.Dtos.Requests.Inward.StockInInvSuggest;
using degree_management.application.Dtos.Responses.StockInInvSuggest;
using degree_management.application.Dtos.Responses.StockInInvSuggestDetail;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;
using degree_management.domain.Enums;

namespace degree_management.infrastructure.Repositories;

public class InwardRepository(
    IRepositoryBase<StockInInvSuggest> stockInSuggestRepo,
    IRepositoryBase<StockInInvSuggestDetail> stockInSuggestDetailRepo,
    IRepositoryBase<Inventory> inventoryRepositoryBase,
    IInventoryRepository inventoryRepo,
    IMapper mapper) : IInwardRepository
{
    public async Task<CreateStockInInvSuggestDto> GetAddStockInInvRequestAsync(string prefix)
    {
        if (string.IsNullOrEmpty(prefix))
        {
            throw new ArgumentException("Prefix cannot be null or empty.", nameof(prefix));
        }

        var code = prefix + DateTime.Now.ToString("dd.MM.yy.HHmm");
        var entity = new CreateStockInInvSuggestDto
        {
            Id = 0,
            Code = code,
            WarehouseId = 0,
            RequestPersonId = null,
            StockInInvSuggestDetails = new List<StockInInvSuggestDetailDto>(),
            Status = StockInInvSuggestStatus.PENDING,
            Note = null,
        };

        return await Task.FromResult(entity);
    }

    public async Task<bool> AddStockInInvRequestAsync(StockInInvSuggest stockInInv)
    {
        var newStockInInv = new StockInInvSuggest
        {
            Code = stockInInv.Code,
            WarehouseId = stockInInv.WarehouseId,
            RequestPersonId = stockInInv.RequestPersonId,
            Status = stockInInv.Status,
            Note = stockInInv.Note,
        };
        await stockInSuggestRepo.AddAsync(newStockInInv);
        bool mainSaveSuccess = await stockInSuggestRepo.SaveChangesAsync() > 0;

        if (!mainSaveSuccess)
            return false;
        if (stockInInv.StockInInvSuggestDetails != null && stockInInv.StockInInvSuggestDetails.Any())
        {
            var stockInDetails = stockInInv.StockInInvSuggestDetails.Select(
                detail => new StockInInvSuggestDetail
                {
                    StockInInvSuggestId = newStockInInv.Id,
                    DegreeTypeId = detail.DegreeTypeId,
                    Quantity = detail.Quantity
                }).ToList().Distinct();

            await stockInSuggestDetailRepo.AddRangeAsync(stockInDetails);
            bool detailsSaveSuccess = await stockInSuggestDetailRepo.SaveChangesAsync() > 0;

            if (!detailsSaveSuccess)
                return false;
        }

        return true;
    }


    public async Task<bool> UpdateStockInInvRequestAsync(StockInInvSuggest stockInInv)
    {
        await stockInSuggestRepo.UpdateAsync(s => s.Id == stockInInv.Id, stockInInv);
        bool isSuccess = await stockInSuggestRepo.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<StockInInvSuggest> GetStockInInvRequestAsync(int stockInInvId)
    {
        var stockInInv = await stockInSuggestRepo.GetByFieldAsync("Id", stockInInvId);
        var stockInSuggestDetails =
            await stockInSuggestDetailRepo.FindAsync(s => s.StockInInvSuggestId == stockInInvId);
        stockInInv.StockInInvSuggestDetails = stockInSuggestDetails.Distinct().ToList();
        return stockInInv;
    }

    public async Task<bool> ApproveStockInInvRequestAsync(ApproveStockInInvSuggestRequest request)
    {
        var stockInInvReq = await stockInSuggestRepo.GetByFieldAsync("Id", request.StockInInvId);
        if (stockInInvReq.Status != 1)
        {
            return false;
        }
        stockInInvReq.Status = request.IsApproved ? 3 : 2;
        await stockInSuggestRepo.UpdateAsync(s => s.Id == stockInInvReq.Id, stockInInvReq);
        await stockInSuggestRepo.SaveChangesAsync();

        var stockInSuggestDetails =
            await stockInSuggestDetailRepo.FindAsync(s => s.StockInInvSuggestId == stockInInvReq.Id);

        var stockInInvSuggestDetails = stockInSuggestDetails as StockInInvSuggestDetail[] ?? stockInSuggestDetails.ToArray();
        if (request.IsApproved  && stockInInvSuggestDetails.Any())
        {
            var stockInRequests = stockInInvSuggestDetails
                .Select(detail => new StockInInvRequest(
                    WarehouseId: stockInInvReq.WarehouseId,
                    DegreeTypeId: detail.DegreeTypeId,
                    Quantity: detail.Quantity,
                    Description: ""
                )).ToList();

            foreach (var stockInRequest in stockInRequests)
            {
                await inventoryRepo.StockInAsync(stockInRequest);
            }
        }
        return true;
    }


    public async Task<PaginatedResult<StockInInvSuggestDto>> GetStockInInvRequestsAsync(
        PaginationRequest paginationRequest)
    {
        var includes = new List<Expression<Func<StockInInvSuggest, object>>>
        {
            m => m.Warehouse!
        };

        var result = await stockInSuggestRepo.GetPageWithIncludesAsync(
            paginationRequest,
            selector: m => new StockInInvSuggestDto
            {
                Id = m.Id,
                Code = m.Code,
                WarehouseId = m.WarehouseId,
                RequestPersonId = m.RequestPersonId,
                WarehouseName = m.Warehouse!.Name,
                Note = m.Note,
                Status = (StockInInvSuggestStatus)m.Status!,
            },
            includes: includes
        );

        return result;
    }
}