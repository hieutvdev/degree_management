using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Dtos.Responses.Faculty;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Faculty.GetFaculties;

public class GetFacultiesHandler (IFacultyRepository facultyRepo, IMapper mapper) : IQueryHandler<GetFacultiesQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetFacultiesQuery request, CancellationToken cancellationToken)
    {
        var faculities = await facultyRepo.GetPageAsync(request.PaginationRequest, cancellationToken);
        return new ResponseBase(faculities);
    }
}