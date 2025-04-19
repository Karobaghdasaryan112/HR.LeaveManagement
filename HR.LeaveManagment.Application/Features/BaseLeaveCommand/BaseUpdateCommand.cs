
using MediatR;

namespace HR.LeaveManagment.Application.Features.BaseLeaveCommand
{
    public class BaseUpdateCommand<TDto> : IRequest<Unit>
    {
        public TDto Dto { get; set; }
    }
}
