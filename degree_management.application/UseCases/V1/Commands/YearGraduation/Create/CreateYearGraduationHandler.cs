using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.Faculty.Create;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.YearGraduation.Create;

public class CreateYearGraduationHandler(IYearGraduationRepository yearGraduationRepo, IMapper mapper)
    : ICommandHandler<CreateYearGraduationCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(CreateYearGraduationCommand request, CancellationToken cancellationToken)
    {
        var year = mapper.Map<domain.Entities.YearGraduation>(request.Request);
        var isSuccess = await yearGraduationRepo.CreateAsync(year);
        return new ResponseBase(Data: year.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Year created successfully" : "Year could not be created");
    }
}