using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reto.Application.Commands.CreateProduct;
using Reto.Application.Commands.UpdateProduct;
using Reto.Application.DTOs.Products;
using Reto.Application.Queries.GetListProduct;
using Reto.Application.Queries.GetProductById;

namespace Reto.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProductsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
		{
			var productId = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetById), new { id = productId }, productId);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
		{
			return Ok(await _mediator.Send(command));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetProductByIdDto?>> GetById(Guid id)
		{
			var product = await _mediator.Send(new GetProductByIdQuery(id));
			if (product == null)
				return NotFound();
			return Ok(product);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<GetProductByIdDto>>> GetAll()
		{
			return Ok(await _mediator.Send(new GetListProductQuery()));
		}
	}
}
