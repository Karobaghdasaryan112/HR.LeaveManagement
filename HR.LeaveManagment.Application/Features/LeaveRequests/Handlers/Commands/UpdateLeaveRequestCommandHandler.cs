using AutoMapper;
using FluentValidation;
using HR.LeaveManagment.Application.CustomExcpetions;
using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command;
using HR.LeaveManagment.Application.Persistance.Contracts;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private IValidator<UpdateLeaveRequestDto> _validator;
        private IMapper _mapper;
        public UpdateLeaveRequestCommandHandler(
            IValidator<UpdateLeaveRequestDto> validator,
            ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _validator = validator;
            _leaveRequestRepository = leaveRequestRepository;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.UpdateLeaveRequestDto, cancellationToken);

            if (!validationResult.IsValid)
                throw new CustomValidationException(validationResult);

            if (request.UpdateLeaveRequestDto != default)
            {
                var updatedLeaveRequest = _mapper.Map<Domain.LeaveRequest>(request);

                await _leaveRequestRepository.UpdateAsync(updatedLeaveRequest);
            }
            else if (request.UpdateLeaveRequestDto != default)
            {
                var updatedLeaveRequest = await _leaveRequestRepository.GetAsync(request.ChangeLeaveRequestApprovalDto.Id);

                await _leaveRequestRepository.ChangeApprovalStatus(updatedLeaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
            }

            return Unit.Value;
        }
    }
}
