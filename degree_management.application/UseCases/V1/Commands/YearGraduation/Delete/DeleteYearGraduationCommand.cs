using degree_management.application.Dtos.Faculty;
using degree_management.application.Dtos.Requests.YearGraduation;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.YearGraduation.Delete;

public record DeleteYearGraduationCommand(DeleteYearGraduationRequest Request) : ICommand<ResponseBase>;