using AutoMapper;
using Application.DTOs;

namespace Application.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.Employee, EmployeeDTO>()
            .ForMember(e => e.DepartmentDescription, 
                opt => opt.MapFrom(src => src.Department.Description))
            .ForMember(e => e.CreatedUserName,
                opt => opt.MapFrom(src => src.CreatedUser.UserName))
            .ForMember(e => e.UpdatedUserName,
                opt => opt.MapFrom(src => src.UpdatedUser.UserName));
    }
}
