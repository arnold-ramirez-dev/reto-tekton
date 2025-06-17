using Microsoft.Extensions.Options;
using Reto.Domain.Interfaces;
using Reto.Infrastructure.Models;
using Reto.Shared;

namespace Reto.Infrastructure.Implements
{
    public sealed class DiscountService : IDiscountService
    {
        private readonly IHttpRequester _http;
        private readonly IOptionsMonitor<RZConfig> _cfg;

        public DiscountService(IHttpRequester http, IOptionsMonitor<RZConfig> cfg) =>
            (_http, _cfg) = (http, cfg);

        public async Task<decimal> GetDiscountAsync(int productId, CancellationToken ct = default)
        {
            var dto = await _http.GetAsync<DiscountDto>(
                          $"{_cfg.CurrentValue.UrlDiscount.TrimEnd('/')}/{productId}", ct)
                      ?? new DiscountDto { Discount = 0 };

            return Math.Clamp(dto.Discount, 0m, 100m);
        }
    }
}
