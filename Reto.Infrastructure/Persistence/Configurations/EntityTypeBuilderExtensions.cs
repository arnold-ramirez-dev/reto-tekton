using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reto.Domain.Common;

namespace Reto.Infrastructure.Persistence.Configurations
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseEntity
        {
            builder.Property(p => p.Id).IsRequired();

            builder.Property(p => p.CreatedUser).HasMaxLength(100).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.Property(p => p.UpdatedUser).HasMaxLength(100);
            builder.Property(p => p.UpdatedAt);

            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            builder.Property(p => p.DeletedUser).HasMaxLength(100);
            builder.Property(p => p.DeletedAt);
        }
    }
}
