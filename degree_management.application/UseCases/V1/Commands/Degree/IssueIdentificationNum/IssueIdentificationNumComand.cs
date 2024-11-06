using degree_management.application.Dtos.Requests.Degree;
using degree_management.application.Dtos.Responses;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Degree.IssueIdentificationNum;

public record IssueIdentificationNumComand(IssueIdentificationNumRequest Request) : ICommand<ResponseBase>;