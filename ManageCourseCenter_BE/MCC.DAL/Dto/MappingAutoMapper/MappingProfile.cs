using AutoMapper;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.AcademicTranscriptDto;
using MCC.DAL.Dto.CartDto;
using MCC.DAL.Dto.CartItemDto;
using MCC.DAL.Dto.ChildDto;
using MCC.DAL.Dto.ChildrenClassDto;
using MCC.DAL.Dto.ClassDto;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Dto.FeedbackDto;
using MCC.DAL.Dto.ManagerDto;
using MCC.DAL.Dto.ParentDto;
using MCC.DAL.Dto.PaymentDto;
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
        EquipmentActivityMappingProfile();
        EquipmentReportMappingProfile();
        ChildrenClassMappingProfile();
        FeedbackMappingProfile();
        CartMappingProfile();
        PaymentMappingProfile();
        CartItemMappingProfile();
        CartMappingProfile();
    }
    private void CartMappingProfile()
    {
        CreateMap<CartCreateDto, Cart>();
        CreateMap<UpdateStatusCartDto, Cart>();
    } 
    private void CartItemMappingProfile()
    {
        CreateMap<UpdateCartItemDto, CartItem>();
    }
    private void FeedbackMappingProfile()
    {
        CreateMap<FeedbackCreateDto, Feedback>();
        CreateMap<Feedback, FeedbackShowDto>();
    }
    private void AcademicTranscriptMappingProfile()
    {
        CreateMap<AcademicTranscriptCreateDto, AcademicTranscript>();
        CreateMap<AcademicTranscriptUpdateDto, AcademicTranscript>();
    }
    private void EquipmentReportMappingProfile()
    {
        CreateMap<EquipmentReportCreateDto, EquipmentReport>();
        CreateMap<EquipmentReportUpdateDto, EquipmentReport>();

    }
    private void EquipmentActivityMappingProfile()
    {
        CreateMap<EquipmentActivityCreateDto, EquipmentActivity>();
    }
    
    private void ClassMappingProfile()
    {
        CreateMap<ClassCreateDto, Class>();
        CreateMap<ClassUpdateDto, Class>();
    }
    private void EquipmentMappingProfile()
    {
        CreateMap<EquipmentCreateDto, Equipment>();
        CreateMap<EquipmentUpdateDto, Equipment>();
    }

    private void ManagerMappingProfile()
    {
        CreateMap<Manager, ManagerShowResponseDto>();
        CreateMap<ManagerCreateDto, Manager>();
        CreateMap<StaffChangePasswordDto, Manager>();
        CreateMap<StaffUpdateDto, Manager>();
    }
    private void TeacherMappingProfile()
    {
        CreateMap<TeacherCreateDto, Teacher>();
        CreateMap<TeacherUpdateDto, Teacher>();
        CreateMap<TeacherChangePasswordDto,  Teacher>();
    }
    private void ParentMappingProfile()
    {
        CreateMap<ParentCreateDto, Parent>();
        CreateMap<ParentUpdateDto, Parent>();
    }
    
    private void PaymentMappingProfile()
    {
        CreateMap<UpdatePaymentStatusDto, Payment>();
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
        CreateMap<CourseUpdateDto, Course>();
    }
    private void ChildrenClassMappingProfile()
    {
        CreateMap<ChildrenClassCreateDto, ChildrenClass>();
    }
}
