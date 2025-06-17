using System.Text.Json.Serialization;

namespace Reto.Infrastructure.Models
{
    public class DiscountDto
    {
        [JsonPropertyName("discount")]
        public decimal Discount { get; set; }

        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; } = default!;
    }
}
