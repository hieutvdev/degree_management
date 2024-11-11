using degree_management.application.Dtos.Requests.Major;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Major.Create;

public record CreateMajorCommand(CreateMajorRequest Request) : ICommand<ResponseBase>;