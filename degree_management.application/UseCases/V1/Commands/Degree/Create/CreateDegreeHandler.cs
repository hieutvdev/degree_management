using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.DegreeType.Create;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Degree.Create;

public class CreateDegreeHandler(IDegreeRepository degreeRepo, IMapper mapper)
    : ICommandHandler<CreateDegreeCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(CreateDegreeCommand request, CancellationToken cancellationToken)
    {
        var degree = mapper.Map<domain.Entities.Degree>(request.Request);
        var isSuccess = await degreeRepo.CreateDegreeAsync(degree);
        return new ResponseBase(Data: degree.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Degree created successfully!" : "Error creating major!");
    }
}