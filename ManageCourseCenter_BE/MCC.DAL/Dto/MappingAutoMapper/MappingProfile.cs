using AutoMapper;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.AcademicTranscriptDto;
using MCC.DAL.Dto.CartDto;
using MCC.DAL.Dto.ChildDto;
using MCC.DAL.Dto.ChildrenClassDto;
using MCC.DAL.Dto.ClassDto;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Dto.FeedbackDto;
using MCC.DAL.Dto.ManagerDto;
using MCC.DAL.Dto.ParentDto;
using MCC.DAL.Dto.RoomDto;
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
        RoomMappingProfile();
        CourseMappingProfile();
        EquipmentMappingProfile();
        ClassMappingProfile();
        EquipmentActivityMappingProfile();
        EquipmentReportMappingProfile();
        AcademicTranscriptMappingProfile();
        ChildrenClassMappingProfile();
        FeedbackMappingProfile();
    }
    private void CartMappingProfile()
    {
        CreateMap<CartCreateDto, Cart>();
    }
    private void FeedbackMappingProfile()
    {
        CreateMap<FeedbackCreateDto, Feedback>();
    }
    private void AcademicTranscriptMappingProfile()
    {
        CreateMap<AcademicTranscriptCreateDto, AcademicTranscript>();
    }
    private void EquipmentReportMappingProfile()
    {
        CreateMap<EquipmentReportCreateDto, EquipmentReport>();
    }
    private void EquipmentActivityMappingProfile()
    {
        CreateMap<EquipmentActivityCreateDto, EquipmenntActivity>();
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
    }
    private void CourseMappingProfile()
    {
        CreateMap<CourseCreateDto, Course>();
    }
    private void ChildrenClassMappingProfile()
    {
        CreateMap<ChildrenClassCreateDto, ChildrenClass>();
    }
}
