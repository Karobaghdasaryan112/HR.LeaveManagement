using AutoMapper;
using HR.LeaveManagment.Application.CustomExcpetions;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagment.Application.Persistance.Contracts;
using HR.LeaveManagment.Domain;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;
        public DeleteLeaveAllocationCommandHandler(
            ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var deletedLeaveAllocation = await _leaveAllocationRepository.GetAsync(request.Id);

            if (deletedLeaveAllocation == null)
                throw new CustomNotFoundException(nameof(LeaveAllocation), request.Id);

            await _leaveAllocationRepository.DeleteAsync(deletedLeaveAllocation);

            return Unit.Value;
        }
    }
}
