using CQRSMediatRExample.Commands;
using CQRSMediatRExample.Queries;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace CQRSMediatRExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpGet(Name="GetProducts")]
        public async Task<ActionResult> GetProduct()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}",Name="GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost(Name="AddProduct")]
        public async Task<ActionResult> AddProduct([FromBody] CreateProductCommand request)
        {
            await _mediator.Send(request);
            return StatusCode(201);
        }
    }
}
