using AutoMapper;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace HR.LeaveManagement.MVC.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateLeaveTypeDto, CreateLeaveTypeVM>().ReverseMap();
            CreateMap<CreateLeaveRequestVM, CreateLeaveRequestDto>()
                       .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartedDate))
                       .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndTime))
                       .ForMember(dest => dest.LeaveTypeId, opt => opt.MapFrom(src => src.LeaveTypeId))
                       .ForMember(dest => dest.RequestComments, opt => opt.MapFrom(src => src.RequestComments))
                       .ReverseMap() // Для двустороннего маппинга
                       .ForMember(dest => dest.StartedDate, opt => opt.MapFrom(src => src.StartDate))
                       .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndDate))
                       .ForMember(dest => dest.LeaveTypeId, opt => opt.MapFrom(src => src.LeaveTypeId))
                       .ForMember(dest => dest.RequestComments, opt => opt.MapFrom(src => src.RequestComments));

            CreateMap<LeaveRequestDto, LeaveRequestVM>()
                .ForMember(q => q.DataRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
                .ForMember(q => q.StartedDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
                .ForMember(q => q.EndTime, opt => opt.MapFrom(x => x.EndDate.DateTime))
                .ForMember(q => q.Employee, opt => opt.MapFrom(x => x.Employee))
                .ReverseMap();
            CreateMap<LeaveRequestListDto, LeaveRequestVM>()
                .ForMember(q => q.DataRequested, opt => opt.MapFrom(x => x.DateRequested.DateTime))
                .ForMember(q => q.StartedDate, opt => opt.MapFrom(x => x.StartDate.DateTime))
                .ForMember(q => q.EndTime, opt => opt.MapFrom(x => x.EndDate.DateTime))
                .ForMember(q => q.Employee, opt => opt.MapFrom(x => x.Employee))
                .ReverseMap()
                .ForMember(x => x.DateRequested, opt => opt.MapFrom(q => new DateTimeOffset(q.DataRequested)))
                .ForMember(x => x.StartDate, opt => opt.MapFrom(q => new DateTimeOffset(q.StartedDate)))
                .ForMember(x => x.EndDate, opt => opt.MapFrom(q => new DateTimeOffset(q.EndTime)))
                .ForMember(q => q.Employee, opt => opt.MapFrom(x => x.Employee));

            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveAllocationDto, LeaveAllocationVM>().ReverseMap();
            CreateMap<EmployeeVM, Employee>().ReverseMap();
        }
    }
}
