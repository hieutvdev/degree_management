﻿using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;
using degree_management.constracts.Pagination;

namespace degree_management.application.UseCases.V1.Queries.StockInRequest.GetStockInRequests;

public record GetStockInRequestsQuery(PaginationRequest PaginationRequest) : IQuery<ResponseBase>;