using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Faculty.GetSelectFaculites;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Warehouse.GetSelectWarehouses;

public class GetSelectWarehousesHandler (IWarehouseRepository warehouseRepo, IMapper mapper) : IQueryHandler<GetSelectWarehousesQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetSelectWarehousesQuery request, CancellationToken cancellationToken)
    {
        var warehousesSelect = await warehouseRepo.GetSelectWarehousesAsync();
        return new ResponseBase(warehousesSelect);
    }
}