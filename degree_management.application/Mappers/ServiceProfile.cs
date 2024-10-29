using AutoMapper;
using degree_management.application.Dtos.Faculty;
using degree_management.application.Dtos.Responses.Faculty;
using degree_management.domain.Entities;

namespace degree_management.application.Mappers;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<CreateFacultyRequest, Faculty>().ReverseMap();
        CreateMap<UpdateFacultyRequest, Faculty>().ReverseMap();
        CreateMap<DeleteFacultyRequest, Faculty>().ReverseMap();
        CreateMap<Faculty, FacultyDto>().ReverseMap();
    }
}