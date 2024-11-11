using degree_management.application.Dtos.Requests.Inventory;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Degree;
using degree_management.application.Dtos.Responses.Inventory;
using degree_management.constracts.Pagination;

namespace degree_management.application.Repositories;

public interface IInventoryRepository
{
    Task<bool> CreateInventoryAsync(Inventory inventoryModel);
    Task<bool> UpdateInventoryAsync(Inventory inventoryModel);
    Task<bool> DeleteInventoryAsync(int inventoryId);
    Task<bool> StockInAsync(StockInInvRequest stockInInvRequest);
    Task<bool> StockOutAsync(List<StockOutRequest> stockOutRequests);
    Task<Inventory> GetInventoryByIdAsync(int inventoryId);
    Task<PaginatedResult<InventoryDto>> GetListInventoriesAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default);
}