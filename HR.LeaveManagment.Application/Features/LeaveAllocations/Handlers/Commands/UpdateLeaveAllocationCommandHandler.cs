using AutoMapper;
using FluentValidation;
using HR.LeaveManagment.Application.CustomExcpetions;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Application.Responses;
using MediatR;
using HR.LeaveManagment.Domain.Entities;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommad, ICommandResponse>
    {
        private IValidator<UpdateLeaveAllocationDto> _validator;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private ICommandResponse _commandResponse;
        private IMapper _mapper;
        public UpdateLeaveAllocationCommandHandler(
            ICommandResponse commandResponse,
            ILeaveAllocationRepository leaveAllocationRepository,
            IValidator<UpdateLeaveAllocationDto> validator,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _commandResponse = commandResponse;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task<ICommandResponse> Handle(UpdateLeaveAllocationCommad request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.UpdateLeaveAllocationDto, cancellationToken);

            BaseCommandResponse baseCommandResponse = default;

            if (!validationResult.IsValid)
            {

                baseCommandResponse = _commandResponse.CreateCommandResponse(
                    "Update Filed",
                    false,
                    request.UpdateLeaveAllocationDto.Id,
                    validationResult.Errors.Select(q => q.ErrorMessage).ToList());
            }

            var updatedLeaveAllocation = _mapper.Map<LeaveAllocation>(request.UpdateLeaveAllocationDto);

            await _leaveAllocationRepository.UpdateAsync(updatedLeaveAllocation);

            baseCommandResponse = _commandResponse.CreateCommandResponse(
                "Update Successful",
                true,
                request.UpdateLeaveAllocationDto.Id,
                default);

            return baseCommandResponse;
        }
    }

}
