using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.DegreeType.Delete;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Degree.Delete;

public class DeleteDegreeHandler(IDegreeRepository degreeRepo, IMapper mapper)
    : ICommandHandler<DeleteDegreeComand, ResponseBase>
{
    public async Task<ResponseBase> Handle(DeleteDegreeComand request, CancellationToken cancellationToken)
    {
        var degree = mapper.Map<domain.Entities.Degree>(request);
        bool isSuccess = await degreeRepo.DeleteDegreeAsync(degree.Id);
        return new ResponseBase(Data: degree.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Degree deleted." : "Degree could not be deleted.");
    }
}