using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.Faculty.Create;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Period.Create;

public class CreatePeriodHandler(IPeriodRepository periodRepo, IMapper mapper)
    : ICommandHandler<CreatePeriodCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(CreatePeriodCommand request, CancellationToken cancellationToken)
    {
        var period = mapper.Map<domain.Entities.Period>(request.Request);
        var isSuccess = await periodRepo.CreateAsync(period);
        return new ResponseBase(Data: period.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Period created successfully" : "Period could not be created");
    }
}