using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Inventory.StockIn;

public class StockInInventoryHandler (IInventoryRepository inventoryRepo, IMapper mapper) : ICommandHandler<StockInInventoryCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(StockInInventoryCommand request, CancellationToken cancellationToken)
    {
        var isSuccess = await inventoryRepo.StockInAsync(request.Request);
        return new ResponseBase(Data: null, IsSuccess: isSuccess, Message: isSuccess ? "Stock In Success" : "Stock In Failed");
    }
}