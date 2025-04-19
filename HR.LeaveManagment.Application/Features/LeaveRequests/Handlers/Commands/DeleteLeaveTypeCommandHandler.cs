using AutoMapper;
using HR.LeaveManagment.Application.CustomExcpetions;
using HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagment.Application.Persistance.Contracts;
using HR.LeaveManagment.Domain;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
    { 
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private IMapper _mapper;

        public DeleteLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,

            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var deletedLeaveRequest = await _leaveRequestRepository.GetAsync(request.Id);

            if (deletedLeaveRequest == null)
                throw new CustomNotFoundException(nameof(LeaveRequest), request.Id);

            await _leaveRequestRepository.DeleteAsync(deletedLeaveRequest);

            return Unit.Value;
        }
    }
}
