using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Commands.Faculty.Delete;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Commands.YearGraduation.Delete;

public class DeleteYearGraduationHandler (IYearGraduationRepository yearGraduationRepo, IMapper mapper) : ICommandHandler<DeleteYearGraduationCommand, ResponseBase>
{
    public async Task<ResponseBase> Handle(DeleteYearGraduationCommand request, CancellationToken cancellationToken)
    {
        var year = mapper.Map<domain.Entities.YearGraduation>(request.Request);
        var isSuccess = await yearGraduationRepo.DeleteAsync(year.Id);
        return new ResponseBase(Data: year.Id, IsSuccess: isSuccess,
            Message: isSuccess ? "Year deleted successfully" : "Year could not be deleted");
    }
}