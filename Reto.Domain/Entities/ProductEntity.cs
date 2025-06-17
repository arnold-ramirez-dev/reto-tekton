using Reto.Domain.Common;
using Reto.Domain.ValueObjects;

namespace Reto.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public VOStatus Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        private ProductEntity()
        {
            Name = string.Empty;
            Description = string.Empty;
            Status = default!;
        }

        public ProductEntity(string name, VOStatus status, int stock, string description, decimal price)
        {
            Name = name;
            Status = status;
            Stock = stock;
            Description = description;
            Price = price;
        }
    }
}
