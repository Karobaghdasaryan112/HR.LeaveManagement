using HR.LeaveManagment.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Command;
using HR.LeaveManagment.Application.Features.LeaveRequests.Requests.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace HR.LeaveManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class leaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public leaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // DELETE api/<leaveRequestController>/5-example
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };

            await _mediator.Send(command);

            return NoContent();
        }

        // GET: api/<leaveRequestController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> GetAsync()
        {
            var query = new GetLeaveRequestListRequest();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        // GET: api/<leaveRequestController>/5-example
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> GetByIdAsync(int id)
        {
            var query = new GetLeaveRequestDetailRequest { Id = id };

            var response = await _mediator.Send(query);

            return Ok(response);
        }


        // Create api/<leaveRequestController>/
        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync([FromBody] CreateLeaveRequestDto leaveRequestDto)
        {
            var command = new CreateLeaveRequestCommand { CreateLeaveRequestDto = leaveRequestDto };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // Update api/<leaveRequestController>/
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateLeaveRequestDto updateLeaveRequestDto)
        {
            var command = new UpdateLeaveRequestCommand { UpdateLeaveRequestDto = updateLeaveRequestDto };

            await _mediator.Send(command);

            return NoContent();
        }

        // Update api/<leaveRequestController>/
        [HttpPut("changeapproval/{id}")]
        public async Task<ActionResult> ChangeApprovalStatusAsync([FromBody] ChangeLeaveRequestApprovalDto changeLeaveRequestApprovalDto,int id)
        {
            var command = new UpdateLeaveRequestCommand { ChangeLeaveRequestApprovalDto = changeLeaveRequestApprovalDto,Id = id };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
