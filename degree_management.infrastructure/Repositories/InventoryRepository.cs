using System.Linq.Expressions;
using AutoMapper;
using degree_management.application.Dtos.Requests.Inventory;
using degree_management.application.Dtos.Responses.Inventory;
using degree_management.application.Repositories;
using degree_management.constracts.Pagination;
using degree_management.domain.Entities;
using degree_management.domain.Enums;

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

    public async Task<bool> StockInAsync(StockInInvRequest stockInInvRequest)
    {
        var inv = await repositoryBase.GetAsync(inventory =>
            inventory.WarehouseId == stockInInvRequest.WarehouseId &&
            inventory.DegreeTypeId == stockInInvRequest.DegreeTypeId);

        var invModel = mapper.Map<Inventory>(stockInInvRequest);

        if (inv == null)
        {
            await repositoryBase.AddAsync(invModel);
        }
        else
        {
            await repositoryBase.UpdateAsync(i => i.Id == inv.Id, new Inventory
            {
                Id = inv.Id,
                DegreeTypeId = inv.DegreeTypeId,
                WarehouseId = inv.WarehouseId,
                Quantity = inv.Quantity + stockInInvRequest.Quantity,
                Description = inv.Description,
            });
        }

        return await repositoryBase.SaveChangesAsync() > 0;
    }

    public async Task<bool> StockOutAsync(List<StockOutRequest> stockOutRequests)
    {
        var tasks = stockOutRequests.Select(async stockOutRequest =>
        {
            var inv = await repositoryBase.GetAsync(inventory =>
                inventory.WarehouseId == stockOutRequest.WarehouseId &&
                inventory.DegreeTypeId == stockOutRequest.DegreeTypeId);

            if (inv == null)
            {
                return false;
            }


            if (inv.Quantity < stockOutRequest.Quantity)
            {
                return false;
            }


            inv.Quantity -= stockOutRequest.Quantity;


            await repositoryBase.UpdateAsync(i => i.Id == inv.Id, inv);

            return true;
        }).ToList();

        var results = await Task.WhenAll(tasks);

        return results.All(result => result);
    }


    public async Task<Inventory> GetInventoryByIdAsync(int id)
    {
        var result = await repositoryBase.GetByFieldAsync("Id", id);
        return result;
    }

    public async Task<PaginatedResult<InventoryDto>> GetListInventoriesAsync(PaginationRequest paginationRequest,
        CancellationToken cancellationToken = default)
    {
        var includes = new List<Expression<Func<Inventory, object>>>
        {
            m => m.Warehouse!,
            m => m.DegreeType!
        };
        var result = await repositoryBase.GetPageWithIncludesAsync(
            paginationRequest,
            selector: inventory => new InventoryDto
            {
                Id = inventory.Id,
                DegreeTypeId = inventory.DegreeType.Id,
                DegreeTypeName = inventory.DegreeType.Name,
                DegreeTypeCode = inventory.DegreeType.Code,
                WarehouseId = inventory.WarehouseId,
                WarehouseName = inventory.Warehouse.Name,
                WarehouseCode = inventory.Warehouse.Code,
                Quantity = inventory.Quantity,
                Description = inventory.Description,
            },
            includes: includes,
            cancellationToken: cancellationToken
        );
        return result;
    }

    public InventoryRepository(IMapper mapper) : this(null, mapper)
    {
    }
}