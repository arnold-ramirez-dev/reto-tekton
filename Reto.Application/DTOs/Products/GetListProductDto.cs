namespace Reto.Application.DTOs.Products
{
	public class GetListProductDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int Stock { get; set; }
		public decimal Price { get; set; }
		public int Status { get; set; }
		public string StatusName { get; set; } = string.Empty;
	}
}
