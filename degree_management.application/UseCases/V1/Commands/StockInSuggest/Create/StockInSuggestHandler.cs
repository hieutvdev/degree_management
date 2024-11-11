using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.StockInSuggest.Create;

public class StockInSuggestHandler(IInwardRepository inwardRepo, IMapper mapper)
    : ICommandHandler<StockInSuggestCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(StockInSuggestCommand request, CancellationToken cancellationToken)
    {
        var stockInSuggest = mapper.Map<StockInInvSuggest>(request.Request);
        var isSuccess = await inwardRepo.AddStockInInvRequestAsync(stockInSuggest);
        return new ResponseBase(Data: stockInSuggest, IsSuccess: isSuccess,
            Message: isSuccess ? "Stock In Suggest Success" : "Stock In Suggest Failed");
    }
}