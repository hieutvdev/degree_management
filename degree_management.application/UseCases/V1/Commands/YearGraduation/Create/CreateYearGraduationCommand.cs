using degree_management.application.Dtos.Faculty;
using degree_management.application.Dtos.Requests.YearGraduation;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.YearGraduation.Create;

public record CreateYearGraduationCommand(CreateYearGraduationRequest Request) : ICommand<ResponseBase>;