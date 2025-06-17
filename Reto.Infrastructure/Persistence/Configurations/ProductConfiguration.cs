using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reto.Domain.Entities;
using Reto.Domain.ValueObjects;


namespace Reto.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.Stock).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)").IsRequired();

            var statusConverter = new ValueConverter<VOStatus, int>(
                            vo => vo.Value,                // a BD
                            v => VOStatus.FromInt(v));    // de BD

            builder.Property(p => p.Status)
                   .HasConversion(statusConverter)
                   .HasColumnName("Status")
                   .IsRequired();

            builder.ConfigureBaseEntity();

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
