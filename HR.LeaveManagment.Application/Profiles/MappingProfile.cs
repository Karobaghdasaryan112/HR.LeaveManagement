using AutoMapper;
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
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();

            CreateMap<CreateLeaveAllocationDto, LeaveAllocationDto>()
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UpdateLeaveAllocationDto, LeaveAllocationDto>()
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now));


            CreateMap<CreateLeaveTypeDto, LeaveTypeDto>();

            CreateMap<UpdateLeaveTypeDto, LeaveTypeDto>();


            CreateMap<CreateLeaveRequestDto, LeaveRequestDto>()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Approved, opt => opt.MapFrom(src => (bool?)null))
                .ForMember(dest => dest.Canceled, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.DateActioned, opt => opt.MapFrom(src => (DateTime?)null));

            CreateMap<UpdateLeaveRequestDto, LeaveRequestDto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Approved, opt => opt.MapFrom(src => (bool?)null))
                .ForMember(dest => dest.Canceled, opt => opt.MapFrom(src => false));

        }
    }
}
