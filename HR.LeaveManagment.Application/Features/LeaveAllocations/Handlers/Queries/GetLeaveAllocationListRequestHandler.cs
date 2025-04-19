using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Queries;
using HR.LeaveManagment.Application.Persistance.Contracts;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;
        public GetLeaveAllocationListRequestHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
        }
        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var LeaveAllocationList = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
            return _mapper.Map<List<LeaveAllocationDto>>(LeaveAllocationList);
        }
    }
}
