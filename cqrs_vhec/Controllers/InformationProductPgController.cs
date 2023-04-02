using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.Command.PostgreCM;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Request.Query.PostgreQ;
using cqrs_vhec.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cqrs_vhec.Request.Query.MongoQ;

namespace cqrs_vhec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationProductPgController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InformationProductPgController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMg")]
        public async Task<IActionResult> GetAllMg()
        {
            var query = new GetAllInformationProductMgQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [HttpGet("GetByIdMg/{id}")]
        public async Task<IActionResult> GetByIdMg(int id)
        {
            var query = new GetByIdInformationProductMgQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetAllPg")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllInformationProductPgQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetByIdPg/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetById<InformationProductPg>(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateInformationProductPgCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInformationProductPgCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteInformationProductPgCommand(id);
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
