using cqrs_vhec.Data;
using cqrs_vhec.Module.Postgre.Entities;
using cqrs_vhec.Request.Command.PostgreCM;
using cqrs_vhec.Request.DTOs;
using cqrs_vhec.Request.Query;
using cqrs_vhec.Request.Query.MongoQ;
using cqrs_vhec.Request.Query.PostgreQ;
using cqrs_vhec.Service.Postgre;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cqrs_vhec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPgController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _host;

        public ProductPgController(IMediator mediator, IWebHostEnvironment host)
        {
            _mediator = mediator;
            _host = host;
        }

        [HttpGet("GetAllMg")]
        public async Task<IActionResult> GetAllMg()
        {
            var query = new GetAllProductMgQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [HttpGet("GetByIdMg/{id}")]
        public async Task<IActionResult> GetByIdMg(int id)
        {
            var query = new GetByIdProductMgQueryMg(id);
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
            var query = new GetAllProductPgQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("GetByIdPg/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetById<ProductPg>(id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreateProductPgDTO command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pathServer = $"{Request.Scheme}://{Request.Host}";
            var query = new CreateProductPgCommand(command, _host.WebRootPath, pathServer);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateProductPgDTO command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != command.Id)
            {
                return BadRequest();
            }
            var pathServer = $"{Request.Scheme}://{Request.Host}";
            var query = new UpdateProductPgCommand(id, command, _host.WebRootPath, pathServer);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductPgCommand(id);
            var result = await _mediator.Send(command);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }

}
