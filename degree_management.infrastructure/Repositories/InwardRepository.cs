using System.Linq.Expressions;
using AutoMapper;
using degree_management.application.Dtos.Responses.StockInInvSuggest;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;
using degree_management.domain.Enums;

namespace degree_management.infrastructure.Repositories;

public class InwardRepository(IRepositoryBase<StockInInvSuggest> stockInSuggestRepo, IMapper mapper) : IInwardRepository
{
    public async Task<StockInInvSuggest> GetAddStockInInvRequestAsync(string prefix)
    {
        if (string.IsNullOrEmpty(prefix))
        {
            throw new ArgumentException("Prefix cannot be null or empty.", nameof(prefix));
        }

        var code = prefix + DateTime.Now.ToString("dd.MM.yy.HHmm");
        var entity = new StockInInvSuggest
        {
            Id = 0,
            Code = code,
            WarehouseId = null,
            RequestPersonId = null,
            StockInInvSuggestDetails = new List<StockInInvSuggestDetail>(),
            Status = StockInInvSuggestStatus.PENDING,
            Note = null,
        };

        return await Task.FromResult(entity);
    }

    public async Task<bool> AddStockInInvRequestAsync(StockInInvSuggest stockInInv)
    {
        await stockInSuggestRepo.AddAsync(stockInInv);
        bool isSuccess = await stockInSuggestRepo.SaveChangesAsync() > 0;
        return isSuccess;
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
        return stockInInv;
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
                Status = m.Status,
            },
            includes: includes
        );

        return result;
    }
}