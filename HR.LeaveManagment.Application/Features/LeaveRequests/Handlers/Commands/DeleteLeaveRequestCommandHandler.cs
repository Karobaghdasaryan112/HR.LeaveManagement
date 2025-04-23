using AutoMapper;
using HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command;
using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Application.Responses;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, ICommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private IMapper _mapper;
        private ICommandResponse _commandResponse;

        public DeleteLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            ICommandResponse commandResponse,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _commandResponse = commandResponse;
        }

        public async Task<ICommandResponse> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse baseCommandResponse = default;
            var deletedLeaveRequest = await _leaveRequestRepository.GetAsync(request.Id);

            if (deletedLeaveRequest == null)
            {
                baseCommandResponse = _commandResponse.CreateCommandResponse(
                    "Delete Failed",
                    false,
                    request.Id,
                    new List<string> { "Leave Request Not Found" });
            }

            await _leaveRequestRepository.DeleteAsync(deletedLeaveRequest);

            baseCommandResponse = _commandResponse.CreateCommandResponse(
                "Delete Successful",
                true,
                request.Id,
                default);

            return baseCommandResponse;
        }
    }
}
