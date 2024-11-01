using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.DegreeType.Update;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Degree.Update;

public class UpdateDegreeHandler(IDegreeRepository degreeRepo, IMapper mapper)
    : ICommandHandler<UpdateDegreeComand, ResponseBase>
{
    public async Task<ResponseBase> Handle(UpdateDegreeComand request, CancellationToken cancellationToken)
    {
        var degree = mapper.Map<domain.Entities.Degree>(request.Request);
        var isSuccess = await degreeRepo.UpdateDegreeAsync(degree);
        return new ResponseBase(Data: degree, IsSuccess: isSuccess,
            Message: isSuccess ? "Degree updated" : "Degree could not be updated");
    }
}