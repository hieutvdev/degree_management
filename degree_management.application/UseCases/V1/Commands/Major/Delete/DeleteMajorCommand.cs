using degree_management.application.Dtos.Requests.Major;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Major.Delete;

public record DeleteMajorCommand(DeleteMajorRequest Request) : ICommand<ResponseBase>;