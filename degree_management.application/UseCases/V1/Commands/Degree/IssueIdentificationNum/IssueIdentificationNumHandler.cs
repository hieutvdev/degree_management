using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Degree.IssueIdentificationNum;

public class IssueIdentificationNumHandler(IDegreeRepository degreeRepo, IMapper mapper)
    : ICommandHandler<IssueIdentificationNumComand, ResponseBase>
{
    public async Task<ResponseBase> Handle(IssueIdentificationNumComand request, CancellationToken cancellationToken)
    {
        bool isSuccess = await degreeRepo.IssueIdentificationNumAsync(request.Request);
        return new ResponseBase(Data: null, IsSuccess: isSuccess,
            Message: isSuccess ? "IssueIdentificationNum successful" : "IssueIdentificationNum unsuccessful");
    }
}