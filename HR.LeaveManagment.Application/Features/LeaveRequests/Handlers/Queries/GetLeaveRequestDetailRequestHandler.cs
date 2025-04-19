using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagment.Application.Persistance.Contracts;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Handlers.Queries
{
    public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private IMapper _mapper;
        public GetLeaveRequestDetailRequestHandler(
            ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            var LeaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails(request.Id);
            return _mapper.Map<LeaveRequestDto>(LeaveRequest);
        }
    }
}
