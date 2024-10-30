﻿using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;
using degree_management.constracts.Pagination;

namespace degree_management.application.UseCases.V1.Queries.Degree.GetDegrees;

public record GetDegreesQuery(PaginationRequest PaginationRequest) : IQuery<ResponseBase>;