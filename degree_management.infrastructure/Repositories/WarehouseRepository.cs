using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Warehouse;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.infrastructure.Repositories;

public class WarehouseRepository(IRepositoryBase<Warehouse> repositoryBase, IMapper mapper) : IWarehouseRepository
{
    public async Task<bool> CreateWarehouseAsync(Warehouse warehouseModel)
    {
        await repositoryBase.AddAsync(warehouseModel);
        var isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> UpdateWarehouseAsync(Warehouse warehouseModel)
    {
        await repositoryBase.UpdateAsync(w => w.Id == warehouseModel.Id, warehouseModel);
        var isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> DeleteWarehouseAsync(int warehouseId)
    {
        await repositoryBase.DeleteAsync(w => w.Id == warehouseId);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<Warehouse> GetWarehouseByIdAsync(int warehouseId)
    {
        var result = await repositoryBase.GetByFieldAsync("Id", warehouseId);
        return result;
    }

    public async Task<PaginatedResult<WarehouseDto>> GetListWarehousesAsync(PaginationRequest paginationRequest,
        CancellationToken cancellationToken = default)
    {
        var result = await repositoryBase.GetPageAsync(paginationRequest, cancellationToken);
        var data = mapper.Map<IEnumerable<Warehouse>, IEnumerable<WarehouseDto>>(result.Data).ToList();
        return new PaginatedResult<WarehouseDto>(data: data, pageSize: paginationRequest.PageSize,
            pageIndex: paginationRequest.PageIndex, count: data.Count());
    }

    public async Task<IEnumerable<SelectDto>> GetSelectWarehousesAsync()
    {
        var result = await repositoryBase.GetSelectAsync(
            selector: type => new SelectDto { Text = type.Code, Value = type.Id });
        return result;
    }
}