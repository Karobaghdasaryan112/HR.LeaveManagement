using AutoMapper;
using MediatR;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagment.Application.Persistance.Contracts;
using HR.LeaveManagment.Domain;
using FluentValidation;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.CustomExcpetions;


namespace HR.LeaveManagment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveRequestRepository;
        private IMapper _mapper;
        private readonly IValidator<CreateLeaveTypeDto> _validator;
        public CreateLeaveTypeCommandHandler(
            IValidator<CreateLeaveTypeDto> validator,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveTypeRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var ValidatorResult = await _validator.ValidateAsync(request.CreateLeaveTypeDto, cancellationToken);
            if (!ValidatorResult.IsValid)
                throw new CustomValidationException(ValidatorResult);


            var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);

            leaveType = await _leaveRequestRepository.AddAsync(leaveType);

            return leaveType.Id;
        }
    }
}
