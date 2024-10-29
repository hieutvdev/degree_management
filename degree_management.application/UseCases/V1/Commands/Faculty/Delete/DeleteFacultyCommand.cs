using degree_management.application.Dtos.Faculty;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Faculty.Delete;

public record DeleteFacultyCommand(DeleteFacultyRequest Request) : ICommand<ResponseBase>;