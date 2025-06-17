using MediatR;
using Reto.Domain.Entities;
using Reto.Domain.Interfaces;
using Reto.Domain.ValueObjects;
using Reto.Shared;

namespace Reto.Application.Commands.CreateProduct
{
	public class CreateProductHandler : IRequestHandler<CreateProductCommand, RZResponse<Guid>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public CreateProductHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<RZResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var status = VOStatus.FromInt(request.Status);

			var product = new ProductEntity(
				request.Name,
				status,
				request.Stock,
				request.Description,
				request.Price
			);

			await _unitOfWork.Products.AddAsync(product);
			await _unitOfWork.SaveChangesAsync(cancellationToken);

			return RZResponse<Guid>.Success(product.Id, "Producto creado correctamente.");
		}
	}
}
