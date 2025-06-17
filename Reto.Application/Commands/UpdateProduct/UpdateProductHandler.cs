using MediatR;
using Reto.Domain.Interfaces;
using Reto.Domain.ValueObjects;
using Reto.Shared;

namespace Reto.Application.Commands.UpdateProduct
{
	public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, RZResponse<Unit>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public UpdateProductHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<RZResponse<Unit>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
			if (product == null)
			{
				throw new KeyNotFoundException("Product not found.");
			}

			product.Name = request.Name;
			product.Description = request.Description;
			product.Stock = request.Stock;
			product.Price = request.Price;
			product.Status = VOStatus.FromInt(request.Status);

			await _unitOfWork.Products.UpdateAsync(product);
			await _unitOfWork.SaveChangesAsync(cancellationToken);

			return RZResponse<Unit>.Success(Unit.Value, "Producto actualizado correctamente.");
		}
	}
}
