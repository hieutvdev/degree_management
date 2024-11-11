using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Faculty.GetFaculties;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Specialization.GetSpecializations;

public class GetSpecializationsHandler (ISpecializationRepository specializationRepo, IMapper mapper) : IQueryHandler<GetSpecializationsQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetSpecializationsQuery request, CancellationToken cancellationToken)
    {
        var specializations = await specializationRepo.GetPageAsync(request.PaginationRequest, cancellationToken);
        return new ResponseBase(specializations);
    }
}