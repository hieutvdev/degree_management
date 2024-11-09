using AutoMapper;
using degree_management.application.Repositories;
using degree_management.domain.Entities;
using degree_management.domain.Enums;

namespace degree_management.infrastructure.Repositories;

public class InwardRepository(IRepositoryBase<StockInInvSuggest> stockInSuggestRepo, IMapper mapper) : IInwardRepository
{
    public async Task<StockInInvSuggest> GetStockInInvRequestAsync(string prefix)
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
}