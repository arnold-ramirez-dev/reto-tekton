using Microsoft.EntityFrameworkCore;
using Reto.Domain.Entities;
using Reto.Domain.Interfaces;
using Reto.Infrastructure.Contexts;

namespace Reto.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly RetoDbContext _context;

        public ProductRepository(RetoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task UpdateAsync(ProductEntity product)
        {
            _context.Products.Update(product);
            return Task.CompletedTask;
        }
    }
}
