using AutoMapper;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagment.Application.Persistance.Contracts;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommad, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;
        public UpdateLeaveAllocationCommandHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommad request, CancellationToken cancellationToken)
        {
            var updatedLeaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);

            await _leaveAllocationRepository.UpdateAsync(updatedLeaveAllocation);

            return Unit.Value;
        }
    }

}
