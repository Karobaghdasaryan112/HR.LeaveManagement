using AutoMapper;
using FluentValidation;
using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command;
using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Application.Responses;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, ICommandResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private IValidator<UpdateLeaveRequestDto> _validator;
        private ICommandResponse _commandResponse;
        private IMapper _mapper;
        public UpdateLeaveRequestCommandHandler(
            ICommandResponse commandResponse,
            IValidator<UpdateLeaveRequestDto> validator,
            ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _validator = validator;
            _commandResponse = commandResponse;
            _leaveRequestRepository = leaveRequestRepository;
        }
        public async Task<ICommandResponse> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse baseCommandResponse = default;
            var validationResult = await _validator.ValidateAsync(request.UpdateLeaveRequestDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                baseCommandResponse = _commandResponse.CreateCommandResponse(
                      "Leave request update failed",
                      false,
                      request.UpdateLeaveRequestDto.Id,
                      validationResult.Errors.Select(x => x.ErrorMessage).ToList());
            }

            if (request.UpdateLeaveRequestDto != default)
            {
                var updatedLeaveRequest = _mapper.Map<Domain.Entities.LeaveRequest>(request.UpdateLeaveRequestDto);

                await _leaveRequestRepository.UpdateAsync(updatedLeaveRequest);
            }
            else if (request.UpdateLeaveRequestDto != default)
            {
                var updatedLeaveRequest = await _leaveRequestRepository.GetAsync(request.ChangeLeaveRequestApprovalDto.Id);

                await _leaveRequestRepository.ChangeApprovalStatus(updatedLeaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
            }

            baseCommandResponse = _commandResponse.CreateCommandResponse(
                "Leave request updated successfully",
                true,
                request.UpdateLeaveRequestDto.Id,
                default);

            return baseCommandResponse;
        }
    }
}
