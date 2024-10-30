using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;
using degree_management.constracts.Pagination;

namespace degree_management.application.UseCases.V1.Queries.Inventory.GetInventories;

public record GetInventoriesQuery(PaginationRequest PaginationRequest) : IQuery<ResponseBase>;