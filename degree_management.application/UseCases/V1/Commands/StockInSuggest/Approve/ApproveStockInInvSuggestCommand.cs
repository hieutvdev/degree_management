using degree_management.application.Dtos.Requests.Inward.StockInInvSuggest;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.StockInSuggest.Approve;

public record ApproveStockInInvSuggestCommand(ApproveStockInInvSuggestRequest Request) : ICommand<ResponseBase>;