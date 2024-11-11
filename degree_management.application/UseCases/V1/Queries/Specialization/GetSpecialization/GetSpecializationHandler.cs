using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.application.UseCases.V1.Queries.Faculty.GetFaculty;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Specialization.GetSpecialization;

public class GetSpecializationHandler (ISpecializationRepository specializationRepo, IMapper mapper) : IQueryHandler<GetSpecializationQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetSpecializationQuery request, CancellationToken cancellationToken)
    {
        var specialization = await specializationRepo.GetByIdAsync(request.SpecializationId);
        return new ResponseBase(specialization);
    }
}