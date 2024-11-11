using degree_management.application.Dtos.Requests.Inward.StockInInvSuggest;
using degree_management.application.Dtos.Responses.StockInInvSuggest;
using degree_management.constracts.Pagination;

namespace degree_management.application.Repositories;

public interface IInwardRepository
{
    Task<CreateStockInInvSuggestDto> GetAddStockInInvRequestAsync(string prefix);
    Task<bool> AddStockInInvRequestAsync(StockInInvSuggest stockInInv);
    Task<bool> UpdateStockInInvRequestAsync(StockInInvSuggest stockInInv);
    Task<StockInInvSuggest> GetStockInInvRequestAsync(int stockInInvId);
    Task<bool> ApproveStockInInvRequestAsync(ApproveStockInInvSuggestRequest request);
    
    Task<PaginatedResult<StockInInvSuggestDto>> GetStockInInvRequestsAsync(PaginationRequest paginationRequest);
}