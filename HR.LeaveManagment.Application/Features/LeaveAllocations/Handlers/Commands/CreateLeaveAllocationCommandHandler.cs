using AutoMapper;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagment.Application.Persistance.Contracts;
using MediatR;


namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>   
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);

            leaveAllocation = await _leaveAllocationRepository.AddAsync(leaveAllocation);

            return leaveAllocation.Id;
        }
    }
}
