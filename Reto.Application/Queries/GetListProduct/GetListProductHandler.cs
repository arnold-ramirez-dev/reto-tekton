using MediatR;
using Reto.Application.DTOs.Products;
using Reto.Domain.Interfaces;
using Reto.Shared;

namespace Reto.Application.Queries.GetListProduct
{

	public class GetListProductHandler : IRequestHandler<GetListProductQuery, RZResponse<IEnumerable<GetListProductDto>>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public GetListProductHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<RZResponse<IEnumerable<GetListProductDto>>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
		{
			var products = await _unitOfWork.Products.GetAllAsync();

			return RZResponse<IEnumerable<GetListProductDto>>.Success(products.Select(p => new GetListProductDto
			{
				Id = p.Id,
				Name = p.Name,
				Description = p.Description,
				Price = p.Price,
				Stock = p.Stock,
				Status = p.Status.Value,
				StatusName = p.Status.Name
			}), "Listado obtenido correctamente.");
		}
	}
}
