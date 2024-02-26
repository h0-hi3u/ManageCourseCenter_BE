using AutoMapper;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ManagerDto;

namespace MCC.DAL.Dto.MappingAutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        ManagerMappingProfile();
    }
    private void ManagerMappingProfile()
    {
        CreateMap<Manager, ManagerShowResponseDto>();
    }
}
