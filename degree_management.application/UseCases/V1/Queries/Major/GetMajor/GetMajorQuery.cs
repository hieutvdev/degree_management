using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Major.GetMajor;

public record GetMajorQuery(int MajorId) : IQuery<ResponseBase>;