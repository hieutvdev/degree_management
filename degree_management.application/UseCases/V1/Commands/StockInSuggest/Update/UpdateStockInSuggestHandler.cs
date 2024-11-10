using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.StockInSuggest.Update;

public class UpdateStockInSuggestHandler(IInwardRepository inwardRepo, IMapper mapper)
    : ICommandHandler<UpdateStockInSuggestCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(UpdateStockInSuggestCommand request, CancellationToken cancellationToken)
    {
        var stockInSuggest = mapper.Map<StockInInvSuggest>(request.Request);
        var isSuccess = await inwardRepo.UpdateStockInInvRequestAsync(stockInSuggest);
        return new ResponseBase(Data: stockInSuggest, IsSuccess: isSuccess,
            Message: isSuccess ? "Update stock In Suggest Success" : "Update stock In Suggest Failed");
    }
}