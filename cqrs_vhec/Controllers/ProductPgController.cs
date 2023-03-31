using cqrs_vhec.Data;
using cqrs_vhec.Request.Command.PostgreCM;
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

        public ProductPgController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllPg")]
        public async Task<IActionResult> GetAllPg()
        {
            var query = new GetAllProductPgQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("GetAllMg")]
        public async Task<IActionResult> GetAllMg()
        {
            var query = new GetAllProductMgQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductPgCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpGet("GetByIdMg/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdProductMgQueryMg(id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }

}
