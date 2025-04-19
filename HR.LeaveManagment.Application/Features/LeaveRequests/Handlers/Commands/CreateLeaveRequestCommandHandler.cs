using AutoMapper;
using HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command;
using HR.LeaveManagment.Application.Persistance.Contracts;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private IMapper _mapper;

        public CreateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {


            var LeaveRequest = _mapper.Map<Domain.LeaveRequest>(request);

            LeaveRequest = await _leaveRequestRepository.AddAsync(LeaveRequest);

            return LeaveRequest.Id;
        }
    }
}
