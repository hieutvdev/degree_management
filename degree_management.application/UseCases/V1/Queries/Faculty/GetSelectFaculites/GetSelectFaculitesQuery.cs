using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Faculty.GetSelectFaculites;

public record GetSelectFaculitesQuery() : IQuery<ResponseBase>;