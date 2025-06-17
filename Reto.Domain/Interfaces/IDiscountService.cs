namespace Reto.Domain.Interfaces
{
    public interface IDiscountService
    {
        //Task<decimal> GetDiscountAsync(Guid productId, CancellationToken ct = default);
        Task<decimal> GetDiscountAsync(int productId, CancellationToken ct = default);
    }
}
