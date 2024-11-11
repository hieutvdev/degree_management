using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.StockInSuggest.Approve;

public class ApproveStockInInvSuggestHandler(IInwardRepository inwardRepo, IMapper mapper)
    : ICommandHandler<ApproveStockInInvSuggestCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(ApproveStockInInvSuggestCommand request, CancellationToken cancellationToken)
    {
        var isSuccess = await inwardRepo.ApproveStockInInvRequestAsync(request.Request);
        return new ResponseBase(Data: null, IsSuccess: isSuccess,
            Message: isSuccess
                ? request.Request.IsApproved ? "Stock In Inv Approved" : "Stock In Inv Cancelled"
                : "Stock In Inv Denied");
    }
}