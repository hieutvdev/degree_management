namespace degree_management.application.Repositories;

public interface IInwardRepository
{
    Task<StockInInvSuggest> GetStockInInvRequestAsync(string prefix);
    Task<bool> AddStockInInvRequestAsync(StockInInvSuggest stockInInv);
}