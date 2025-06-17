using MediatR;
using Reto.Application.DTOs.Products;
using Reto.Domain.Interfaces;
using Reto.Shared;

namespace Reto.Application.Queries.GetProductById
{
	public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, RZResponse<GetProductByIdDto?>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IStatusCache _statusCache;
		private readonly IDiscountService _discountService;

		public GetProductByIdHandler(IUnitOfWork unitOfWork, IStatusCache statusCache, IDiscountService discountService)
		{
			_unitOfWork = unitOfWork;
			_statusCache = statusCache;
			_discountService = discountService;
		}

		public async Task<RZResponse<GetProductByIdDto?>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
		{
			var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

			if (product == null)
				return RZResponse<GetProductByIdDto?>.Failure("Producto no encontrado");

			var statusName = _statusCache.GetAll().GetValueOrDefault(product.Status.Value, "Unknown");

			// porque mockup.io no admite busqueda por guids
			//var discount = await _discountService.GetDiscountAsync(product.Id, cancellationToken);
			var discount = await _discountService.GetDiscountAsync(2, cancellationToken);
			var final = Math.Round(product.Price * (100m - discount) / 100m, 2);

			return RZResponse<GetProductByIdDto?>.Success(new GetProductByIdDto
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Stock = product.Stock,
				Price = product.Price,
				Status = product.Status.Value,
				StatusName = statusName,
				Discount = discount,
				FinalPrice = final
			}, "Producto obtenido correctamente.");
		}
	}
}
