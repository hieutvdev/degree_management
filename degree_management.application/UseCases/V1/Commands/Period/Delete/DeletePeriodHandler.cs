using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.Period.Delete;

public class DeletePeriodHandler (IPeriodRepository periodRepo, IMapper mapper) : ICommandHandler<DeletePeriodCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(DeletePeriodCommand request, CancellationToken cancellationToken)
    {
        var period = mapper.Map<domain.Entities.Period>(request.Request);
        var isSuccess = await periodRepo.DeleteAsync(period.Id);
        return new ResponseBase(Data: period.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Period deleted successfully" : "Period could not be deleted");
    }
}