using AutoMapper;
using degree_management.application.Dtos.Responses;
using degree_management.application.Repositories;
using degree_management.constracts.CQRS;

namespace degree_management.application.UseCases.V1.Queries.Faculty.GetFaculty;

public class GetFacultyHandler (IFacultyRepository facultyRepo, IMapper mapper) : IQueryHandler<GetFacultyQuery, ResponseBase>
{
    public async Task<ResponseBase> Handle(GetFacultyQuery request, CancellationToken cancellationToken)
    {
        var faculty = await facultyRepo.GetByIdAsync(request.FacultyId);
        return new ResponseBase(faculty);
    }
}