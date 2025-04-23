using HR.LeaveManagment.Application.DTOs.LeaveAllocation;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagment.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class leaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public leaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<leaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> GetAsync()
        {
            var query = new GetLeaveAllocationListRequest();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        // GET: api/<leaveAllocationController>/5-example
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> GetByIdAsync(int id)
        {
            var query = new GetLeaveAllocationDetailRequest { Id = id };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        // Create api/<leaveAllocationController>/
        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync([FromBody] CreateLeaveAllocationDto leaveAllocationDto)
        {
            var command = new CreateLeaveAllocationCommand { LeaveAllocationDto = leaveAllocationDto };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // Update api/<leaveAllocationController>/
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateLeaveAllocationDto updateLeaveAllocationDto)
        {
            var command = new UpdateLeaveAllocationCommad { UpdateLeaveAllocationDto = updateLeaveAllocationDto };

            var response = await _mediator.Send(command);

            return NoContent();
        }

        // DELETE api/<leaveAllocationController>/5-example
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };

            var response = await _mediator.Send(command);

            return NoContent();
        }
    }
}
