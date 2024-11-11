using degree_management.application.Dtos.Faculty;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Faculty.Update;

public record UpdateFacultyCommand(UpdateFacultyRequest Request): ICommand<ResponseBase>;