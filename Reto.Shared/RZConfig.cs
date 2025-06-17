namespace Reto.Shared
{
    public sealed class RZConfig
    {
        public int TimeCacheMinutes { get; init; }
        public string UrlDiscount { get; init; } = default!;
    }
}
