using AutoMapper;
using degree_management.application.Dtos.Responses.Inventory;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;

namespace degree_management.infrastructure.Repositories;

public class InventoryRepository(IRepositoryBase<Inventory> repositoryBase, IMapper mapper) : IInventoryRepository
{
    public async Task<bool> CreateInventoryAsync(Inventory inventoryModel)
    {
        await repositoryBase.AddAsync(inventoryModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> UpdateInventoryAsync(Inventory inventoryModel)
    {
        await repositoryBase.UpdateAsync(i => i.Id == inventoryModel.Id, inventoryModel);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<bool> DeleteInventoryAsync(int id)
    {
        await repositoryBase.DeleteAsync(i => i.Id == id);
        bool isSuccess = await repositoryBase.SaveChangesAsync() > 0;
        return isSuccess;
    }

    public async Task<Inventory> GetInventoryByIdAsync(int id)
    {
        var result = await repositoryBase.GetByFieldAsync("Id", id);
        return result;
    }

    public async Task<PaginatedResult<InventoryDto>> GetListInventoriesAsync(PaginationRequest paginationRequest,
        CancellationToken cancellationToken = default)
    {
        var result = await repositoryBase.GetPageAsync(paginationRequest, cancellationToken);
        var data = mapper.Map<IEnumerable<Inventory>, IEnumerable<InventoryDto>>(result.Data).ToList();
        return new PaginatedResult<InventoryDto>(data: data, pageSize: paginationRequest.PageSize,
            pageIndex: paginationRequest.PageIndex, count: data.Count());
    }
}