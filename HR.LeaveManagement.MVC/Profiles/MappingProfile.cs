using AutoMapper;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveTypeVM, LeaveTypeDto>().ReverseMap();
            CreateMap<CreateLeaveTypeVM, CreateLeaveTypeDto>().ReverseMap();
            CreateMap<UpdateLeaveTypeVM,LeaveTypeDto>()
                .ReverseMap();
            //CreateMap<LeaveAllocationVM, LeaveAllocation>().ReverseMap();
            //CreateMap<LeaveRequestVM, LeaveRequest>().ReverseMap();
        }
    }
}
