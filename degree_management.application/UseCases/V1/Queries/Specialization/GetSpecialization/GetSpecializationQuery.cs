﻿using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Specialization.GetSpecialization;

public record GetSpecializationQuery(int SpecializationId) : IQuery<ResponseBase>;