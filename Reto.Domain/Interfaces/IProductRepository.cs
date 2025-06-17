using Reto.Domain.Entities;

namespace Reto.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(ProductEntity product);
        Task<ProductEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<ProductEntity>> GetAllAsync();
        Task UpdateAsync(ProductEntity product);
    }
}
