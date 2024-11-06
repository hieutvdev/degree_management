using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Specialization.GetSelectSpecializations;

public record GetSelectSpecializationsQuery() : IQuery<ResponseBase>;