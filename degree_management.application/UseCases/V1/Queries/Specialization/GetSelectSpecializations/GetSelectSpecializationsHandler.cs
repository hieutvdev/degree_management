using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Faculty.GetSelectFaculites;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Specialization.GetSelectSpecializations;

public class GetSelectSpecializationsHandler (ISpecializationRepository specializationRepo, IMapper mapper) : IQueryHandler<GetSelectSpecializationsQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetSelectSpecializationsQuery request, CancellationToken cancellationToken)
    {
        var specializationsSelect = await specializationRepo.GetSelectAsync();
        return new ResponseBase(specializationsSelect);
    }
}