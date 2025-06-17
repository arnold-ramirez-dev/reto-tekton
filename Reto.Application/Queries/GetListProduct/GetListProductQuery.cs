using MediatR;
using Reto.Application.DTOs.Products;
using Reto.Shared;

namespace Reto.Application.Queries.GetListProduct
{
    public class GetListProductQuery : IRequest<RZResponse<IEnumerable<GetListProductDto>>>
    {
    }
}
