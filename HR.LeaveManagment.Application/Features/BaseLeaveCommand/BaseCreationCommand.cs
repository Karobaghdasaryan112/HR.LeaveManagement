using HR.LeaveManagment.Application.DTOs.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagment.Application.Features.BaseLeaveCommand
{
    public class BaseCreationCommand<TDto> : IRequest<int>
    {
        public TDto Dto { get; set; }
    }
}
