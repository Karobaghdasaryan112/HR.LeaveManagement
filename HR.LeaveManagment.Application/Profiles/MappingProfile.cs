using AutoMapper;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Domain.Entities;

namespace HR.LeaveManagment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();

            CreateMap<CreateLeaveAllocationDto, LeaveAllocation>();


            CreateMap<UpdateLeaveAllocationDto, LeaveAllocation>();



            CreateMap<CreateLeaveTypeDto, LeaveType>().ReverseMap();

            CreateMap<UpdateLeaveTypeDto, LeaveType>().ReverseMap();


            CreateMap<CreateLeaveRequestDto, LeaveRequest>()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Approved, opt => opt.MapFrom(src => (bool?)null))
                .ForMember(dest => dest.Canceled, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.DateActioned, opt => opt.MapFrom(src => (DateTime?)null));

            CreateMap<UpdateLeaveRequestDto, LeaveRequest>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Approved, opt => opt.MapFrom(src => (bool?)null))
                .ForMember(dest => dest.Canceled, opt => opt.MapFrom(src => false));

            CreateMap<LeaveRequestListDto, LeaveRequestVM>()
                .ForMember(q => q.DataRequested, opt => opt.MapFrom(x => x.DateRequested))
                .ForMember(q => q.StartedDate, opt => opt.MapFrom(x => x.StartDate))
                .ForMember(q => q.EndTime, opt => opt.MapFrom(x => x.EndDate))
                .ReverseMap();

            CreateMap<LeaveRequest, LeaveRequestListDto>()
              .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => src.DataCreated))
              .ReverseMap();
        }
    }
}
