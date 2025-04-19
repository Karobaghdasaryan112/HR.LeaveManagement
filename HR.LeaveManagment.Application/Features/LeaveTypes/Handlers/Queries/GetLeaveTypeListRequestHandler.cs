using AutoMapper;
using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagment.Application.Persistance.Contracts;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var LeaveTypes = await _leaveTypeRepository.GetLeaveTypesWithDetails();
            return _mapper.Map<List<LeaveTypeDto>>(LeaveTypes);
        }
    }
}








