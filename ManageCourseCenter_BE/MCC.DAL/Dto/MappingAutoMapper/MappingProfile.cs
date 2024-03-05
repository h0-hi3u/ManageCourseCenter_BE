using AutoMapper;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.AcademicDto;
using MCC.DAL.Dto.ChildDto;
using MCC.DAL.Dto.ClassDto;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Dto.ManagerDto;
using MCC.DAL.Dto.ParentDto;
using MCC.DAL.Dto.RoomDto;
using MCC.DAL.Dto.TeacherDto;

namespace MCC.DAL.Dto.MappingAutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        AcademicTranscriptMappingProfile();
        ManagerMappingProfile();
        TeacherMappingProfile();
        ParentMappingProfile();
        ChildMappingProfile();
        RoomMappingProfile();
        CourseMappingProfile();
        EquipmentMappingProfile();
        ClassMappingProfile();
    }

    private void AcademicTranscriptMappingProfile()
    {
        CreateMap<AcademicUpdateDto, AcademicTranscript>();
    }
    private void ClassMappingProfile()
    {
        CreateMap<ClassCreateDto, Class>();
    }
    private void EquipmentMappingProfile()
    {
        CreateMap<EquipmentCreateDto, Equipment>();
    }

    private void ManagerMappingProfile()
    {
        CreateMap<Manager, ManagerShowResponseDto>();
        CreateMap<ManagerCreateDto, Manager>();
    }
    private void TeacherMappingProfile()
    {
        CreateMap<TeacherCreateDto, Teacher>();
        CreateMap<TeacherUpdateDto, Teacher>();
    }
    private void ParentMappingProfile()
    {
        CreateMap<ParentCreateDto, Parent>();
    }
    private void ChildMappingProfile()
    {
        CreateMap<ChildCreatDto, Child>();
    }
    private void RoomMappingProfile()
    {
        CreateMap<RoomCreateDto, Room>();
        CreateMap<RoomUpdateDto, Room>();
    }
    private void CourseMappingProfile()
    {
        CreateMap<CourseCreateDto, Course>();
    }
}
