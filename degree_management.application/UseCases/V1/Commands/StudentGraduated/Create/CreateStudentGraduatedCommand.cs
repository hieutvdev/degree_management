using degree_management.application.Dtos.Requests.DegreeType;
using degree_management.application.Dtos.Requests.StudentGraduated;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.StudentGraduated.Create;

public record CreateStudentGraduatedCommand(CreateStudentGraduatedRequest Request): ICommand<ResponseBase>;

public record BulkCreateStudentGraduatedCommand(BulkCreateStudentGraduatedRequest Request): ICommand<ResponseBase>;