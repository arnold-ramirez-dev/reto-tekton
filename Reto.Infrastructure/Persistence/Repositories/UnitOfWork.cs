using Reto.Domain.Interfaces;
using Reto.Infrastructure.Contexts;

namespace Reto.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RetoDbContext _dbContext;

        private IProductRepository? _productRepository;

        public UnitOfWork(RetoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IProductRepository Products => _productRepository ??= new ProductRepository(_dbContext);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Rollback()
        {
        }
    }
}
