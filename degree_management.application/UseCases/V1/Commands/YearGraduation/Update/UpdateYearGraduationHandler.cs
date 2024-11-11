using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.Faculty.Update;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.YearGraduation.Update;

public class UpdateYearGraduationHandler (IYearGraduationRepository yearGraduationRepo, IMapper mapper) : ICommandHandler<UpdateYearGraduationCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(UpdateYearGraduationCommand request, CancellationToken cancellationToken)
    {
        var year = mapper.Map<domain.Entities.YearGraduation>(request.Request);
        var isSuccess = await yearGraduationRepo.UpdateAsync(year);
        return new ResponseBase(Data: year.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Year updated successfully" : "Year could not be updated");
    }
}