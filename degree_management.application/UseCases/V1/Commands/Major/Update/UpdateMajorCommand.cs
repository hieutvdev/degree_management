using degree_management.application.Dtos.Requests.Major;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Major.Update;

public record UpdateMajorCommand(UpdateMajorRequest Request) : ICommand<ResponseBase>;