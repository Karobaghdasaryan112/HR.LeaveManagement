using AutoMapper;
using HR.LeaveManagment.Application.CustomExcpetions;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Application.Responses;
using HR.LeaveManagment.Domain;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, ICommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private ICommandResponse _commandResponse;
        private IMapper _mapper;

        public DeleLeaveTypeCommandHandler(
            ICommandResponse commandResponse,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            _commandResponse = commandResponse;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<ICommandResponse> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse baseCommandResponse = default;

            var deletedLeaveType = await _leaveTypeRepository.GetAsync(request.Id);

            if (deletedLeaveType == null)
            {
                baseCommandResponse = _commandResponse.CreateCommandResponse(
                    "Delete Failed",
                    false,
                    request.Id,
                    new List<string> { "Leave Type Not Found" });
            }

            await _leaveTypeRepository.DeleteAsync(deletedLeaveType);

            baseCommandResponse = _commandResponse.CreateCommandResponse(
                "Delete Successful",
                true,
                request.Id,
                default);

            return baseCommandResponse;
        }
    }
}
