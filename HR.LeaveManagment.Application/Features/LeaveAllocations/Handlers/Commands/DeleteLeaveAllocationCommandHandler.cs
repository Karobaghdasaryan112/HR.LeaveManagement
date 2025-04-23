using AutoMapper;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Application.Responses;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, ICommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private ICommandResponse _commandResponse;
        private IMapper _mapper;
        public DeleteLeaveAllocationCommandHandler(
            ICommandResponse commandResponse,
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _commandResponse = commandResponse;
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<ICommandResponse> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse baseCommandResponse = default;

            var deletedLeaveAllocation = await _leaveAllocationRepository.GetAsync(request.Id);

            if (deletedLeaveAllocation == null)
            {
                baseCommandResponse = _commandResponse.CreateCommandResponse(
                    "Delete Failed",
                    false,
                    request.Id,
                    new List<string> { "Leave Allocation Not Found" });
            }

            await _leaveAllocationRepository.DeleteAsync(deletedLeaveAllocation);

            baseCommandResponse = _commandResponse.CreateCommandResponse(
                "Delete Successful",
                true,
                request.Id,
                default);

            return baseCommandResponse;
        }
    }
}
