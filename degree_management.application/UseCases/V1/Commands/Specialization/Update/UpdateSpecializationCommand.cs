using degree_management.application.Dtos.Faculty;
using degree_management.application.Dtos.Requests.Specialization;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Specialization.Update;

public record UpdateSpecializationCommand(UpdateSpecializationRequest Request): ICommand<ResponseBase>;