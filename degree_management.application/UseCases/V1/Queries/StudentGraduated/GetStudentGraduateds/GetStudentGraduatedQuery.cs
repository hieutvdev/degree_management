using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;
using degree_management.constracts.Pagination;
using MediatR;

namespace degree_management.application.UseCases.V1.Queries.DegreeType.GetDegreeTypes;

public record GetStudentGraduatedsQuery(PaginationRequest PaginationRequest) : IQuery<ResponseBase>;