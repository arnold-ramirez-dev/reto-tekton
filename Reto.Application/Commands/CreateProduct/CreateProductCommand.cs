using MediatR;
using Reto.Shared;

namespace Reto.Application.Commands.CreateProduct
{
	public class CreateProductCommand : IRequest<RZResponse<Guid>>
	{
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public int Stock { get; set; }
		public decimal Price { get; set; }
		public int Status { get; set; }
	}
}
