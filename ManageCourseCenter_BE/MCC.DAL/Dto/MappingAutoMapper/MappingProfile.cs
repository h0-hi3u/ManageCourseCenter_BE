using AutoMapper;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ChildDto;
using MCC.DAL.Dto.ManagerDto;
using MCC.DAL.Dto.ParentDto;
using MCC.DAL.Dto.TeacherDto;

namespace MCC.DAL.Dto.MappingAutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        ManagerMappingProfile();
        TeacherMappingProfile();
        ParentMappingProfile();
        ChildMappingProfile();
    }
    private void ManagerMappingProfile()
    {
        CreateMap<Manager, ManagerShowResponseDto>();
        CreateMap<ManagerCreateDto, Manager>();
    }
    private void TeacherMappingProfile()
    {
        CreateMap<TeacherCreateDto, Teacher>();
    }
    private void ParentMappingProfile()
    {
        CreateMap<ParentCreateDto, Parent>();
    }
    private void ChildMappingProfile()
    {
        CreateMap<ChildCreatDto, Child>();
    }
}
