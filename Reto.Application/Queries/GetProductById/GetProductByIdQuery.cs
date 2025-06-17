using MediatR;
using Reto.Application.DTOs.Products;
using Reto.Shared;

namespace Reto.Application.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<RZResponse<GetProductByIdDto?>>
    {
        public Guid Id { get; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
