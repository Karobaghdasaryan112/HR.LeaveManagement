using HR.LeaveManagment.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDto>>> GetAsync()
        {
            var query = new GetLeaveTypeListRequest();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        // GET: api/<LeaveTypeController>/5-example
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDto>> GetByIdAsync(int id)
        {
            var query = new GetLeaveTypeDetailRequest { Id = id };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        // Create api/<LeaveTypeController>/ 
        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync([FromBody] CreateLeaveTypeDto leaveTypeDto)
        {
            var command = new CreateLeaveTypeCommand { CreateLeaveTypeDto = leaveTypeDto };

            var response = await _mediator.Send(command);

            return Ok(response);
        }
        // DELETE api/<LeaveTypeController>/
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateLeaveTypeDto updateLeaveTypeDto)
        {
            var command = new UpdateLeaveTypeCommand { UpdateLeaveTypeDto = updateLeaveTypeDto };

            var response = await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<LeaveTypeController>/5-example
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };

            var response = await _mediator.Send(command);

            return NoContent();
        }
    }
}
