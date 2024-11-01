using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Warehouse;
using degree_management.constracts.Pagination;

namespace degree_management.application.Repositories;

public interface IWarehouseRepository
{
    Task<bool> CreateWarehouseAsync(Warehouse warehouseModel);
    Task<bool> UpdateWarehouseAsync(Warehouse warehouseModel);
    Task<bool> DeleteWarehouseAsync(int warehouseId);
    Task<Warehouse> GetWarehouseByIdAsync(int warehouseId);
    Task<PaginatedResult<WarehouseDto>> GetListWarehousesAsync(PaginationRequest paginationRequest, CancellationToken cancellationToken = default);
    Task<IEnumerable<SelectDto>> GetSelectWarehousesAsync();
}