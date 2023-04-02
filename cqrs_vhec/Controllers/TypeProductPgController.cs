using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.Command.PostgreCM;
using cqrs_vhec.Request.Query;
using cqrs_vhec.Request.Query.MongoQ;
using cqrs_vhec.Request.Query.PostgreQ;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cqrs_vhec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeProductPgController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TypeProductPgController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllMg")]
        public async Task<IActionResult> GetAllMg()
        {
            var query = new GetAllTypeProductMgQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [HttpGet("GetByIdMg/{id}")]
        public async Task<IActionResult> GetByIdMg(int id)
        {
            var query = new GetByIdTypeProductMgQuery(id);
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
            var query = new GetAllTypeProductPgQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetByIdPg/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetById<TypeProductPg>(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTypeProductPgCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTypeProductPgCommand command)
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
            var command = new DeleteTypeProductPgCommand(id);
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
