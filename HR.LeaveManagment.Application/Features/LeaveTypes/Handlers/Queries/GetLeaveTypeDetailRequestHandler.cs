using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagment.Application.Contracts.Persistance;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailRequestHandler(ILeaveTypeRepository leaveRequestRepository,IMapper mapper)
        {
            _leaveTypeRepository = leaveRequestRepository;
            _mapper = mapper;   
        }
        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var LeaveType = await _leaveTypeRepository.GetLeaveTypeWithDetails(request.Id);
            return _mapper.Map<LeaveTypeDto>(LeaveType);
        }
    }
}
