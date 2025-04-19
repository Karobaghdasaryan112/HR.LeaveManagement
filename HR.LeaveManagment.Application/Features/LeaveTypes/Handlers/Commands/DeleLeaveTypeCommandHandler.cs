using AutoMapper;
using HR.LeaveManagment.Application.CustomExcpetions;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagment.Application.Persistance.Contracts;
using HR.LeaveManagment.Domain;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private IMapper _mapper;

        public DeleLeaveTypeCommandHandler(
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var deletedLeaveType = await _leaveTypeRepository.GetAsync(request.Id);

            if (deletedLeaveType == null)
                throw new CustomNotFoundException(nameof(LeaveType),request.Id);

            await _leaveTypeRepository.DeleteAsync(deletedLeaveType);

            return Unit.Value;
        }
    }  
}
