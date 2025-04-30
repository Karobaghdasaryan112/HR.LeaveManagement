using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Queries;
using HR.LeaveManagment.Application.Contracts.Persistance;
using MediatR;
using HR.LeaveManagment.Application.Contracts.Identity;
using HR.LeaveManagment.Domain.Entities;
using Microsoft.AspNetCore.Http;
using HR.LeaveManagment.Application.Models.Identity;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private IMapper _mapper;
        public GetLeaveAllocationListRequestHandler(
            IHttpContextAccessor httpContextAccessor,
            IUserService userService,
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
        }
        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
                var leaveAllocations = new List<LeaveAllocation>();
                var allocations = new List<LeaveAllocationDto>();

                if (request.IsLoggedInUser)
                {
                    var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                        q => q.Type == "uid")?.Value;
                    leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails(userId);

                    var employee = await _userService.GetEmployee(userId);
                    allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
                    foreach (var alloc in allocations)
                    {
                        alloc.Employee = employee;
                    }
                }
                else
                {
                    leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
                    allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
                    foreach (var req in allocations)
                    {
                        req.Employee = await _userService.GetEmployee(req.EmployeeId);
                    }
                }

                return allocations;
        }
    }
}
