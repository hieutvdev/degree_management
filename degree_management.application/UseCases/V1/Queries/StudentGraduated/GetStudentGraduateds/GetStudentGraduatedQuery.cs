using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;
using degree_management.constracts.Specifications;

namespace degree_management.application.UseCases.V1.Queries.StudentGraduated.GetStudentGraduateds;

public record GetStudentGraduatedsQuery(SearchBaseModel SearchBase) : IQuery<ResponseBase>;