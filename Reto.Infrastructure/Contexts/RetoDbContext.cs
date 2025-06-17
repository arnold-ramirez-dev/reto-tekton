using Microsoft.EntityFrameworkCore;
using Reto.Domain.Entities;
using Reto.Infrastructure.Persistence.Constants;

namespace Reto.Infrastructure.Contexts
{
    public class RetoDbContext : DbContext
    {
        public RetoDbContext(DbContextOptions<RetoDbContext> options)
            : base(options) { }

        public DbSet<ProductEntity> Products => Set<ProductEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema.Reto);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RetoDbContext).Assembly);
        }
    }
}
