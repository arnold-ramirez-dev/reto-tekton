using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Reto.Domain.Interfaces;
using Reto.Domain.ValueObjects;
using Reto.Shared;
using System.Collections.Immutable;

namespace Reto.Infrastructure.Implements
{
    public sealed class StatusCache : IStatusCache
    {
        private const string CacheKey = "product-statuses";

        private readonly IMemoryCache _cache;
        private readonly IOptionsMonitor<RZConfig> _options;

        public StatusCache(IMemoryCache cache, IOptionsMonitor<RZConfig> options)
        {
            _cache = cache;
            _options = options;
        }

        private TimeSpan CurrentTtl =>
            TimeSpan.FromMinutes(Math.Max(1, _options.CurrentValue.TimeCacheMinutes));

        public IReadOnlyDictionary<int, string> GetAll() =>
            _cache.GetOrCreate(CacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = CurrentTtl;
                entry.SetPriority(CacheItemPriority.High);
                return VOStatus.All.ToImmutableDictionary(s => s.Value, s => s.Name);
            })!;
    }
}
