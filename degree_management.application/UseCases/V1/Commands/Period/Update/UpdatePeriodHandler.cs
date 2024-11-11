using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.Faculty.Update;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Period.Update;

public class UpdatePeriodHandler (IPeriodRepository periodRepo, IMapper mapper) : ICommandHandler<UpdatePeriodCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(UpdatePeriodCommand request, CancellationToken cancellationToken)
    {
        var period = mapper.Map<domain.Entities.Period>(request.Request);
        var isSuccess = await periodRepo.UpdateAsync(period);
        return new ResponseBase(Data: period.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Period updated successfully" : "Period could not be updated");
    }
}