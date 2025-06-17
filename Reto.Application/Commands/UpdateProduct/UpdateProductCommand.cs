using MediatR;
using Reto.Shared;

namespace Reto.Application.Commands.UpdateProduct
{
	public class UpdateProductCommand : IRequest<RZResponse<Unit>>
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int Stock { get; set; }
		public decimal Price { get; set; }
		public int Status { get; set; }
	}
}
