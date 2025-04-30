using AutoMapper;
using FluentValidation;
using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagment.Application.Contracts.Persistance;
using HR.LeaveManagment.Application.Responses;
using MediatR;
using HR.LeaveManagment.Domain.Entities;
using HR.LeaveManagment.Application.Contracts.Identity;


namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, ICommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private IValidator<CreateLeaveAllocationDto> _validator;
        private ICommandResponse _commandResponse;
        private readonly IUserService _userService;
        private IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(
            IUserService userService,
            ILeaveTypeRepository leaveTypeRepository,
            IValidator<CreateLeaveAllocationDto> validator,
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper,
            ICommandResponse commandResponse)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _userService = userService;
            _validator = validator;
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _commandResponse = commandResponse;
        }

        public async Task<ICommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.LeaveAllocationDto, cancellationToken);

            BaseCommandResponse BaseCommandResponse = default;
            if (!validationResult.IsValid)
            {
                BaseCommandResponse = _commandResponse.CreateCommandResponse(
                    "Creation Filed",
                    false,
                    request.LeaveAllocationDto.Id,
                    validationResult.Errors.Select(q => q.ErrorMessage).ToList());
            }
            else
            {
                var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
                var leaveType = await _leaveTypeRepository.GetLeaveTypeWithDetails(leaveAllocation.LeaveTypeId);
                var Employees = await _userService.GetEmployees();
                var Allocations = new List<LeaveAllocation>();
                var period = DateTime.Now.Year;
                foreach (var item in Employees)
                {
                    if (await _leaveAllocationRepository.AllocationExists(item.Id, leaveAllocation.LeaveTypeId, leaveAllocation.Period))
                        continue;
                    Allocations.Add(new LeaveAllocation()
                    {
                        EmployeeId = item.Id,
                        LeaveTypeId = leaveAllocation.LeaveTypeId,
                        NumberOFDays = leaveType.DefaultDays,
                        Period = period,
                    });
                }
                  await _leaveAllocationRepository.AddAllocations(Allocations);

                BaseCommandResponse = _commandResponse.CreateCommandResponse(
                    "Creation Successful",
                    true,
                    leaveAllocation.Id,
                    default);
            }
            return BaseCommandResponse;
        }
    }
}
