using Reto.Domain.Interfaces;
using System.Net.Http.Json;

namespace Reto.Infrastructure.Implements
{
    public sealed class HttpRequester : IHttpRequester
    {
        private readonly HttpClient _http;

        public HttpRequester(HttpClient http) => _http = http;

        public async Task<T?> GetAsync<T>(string url, CancellationToken ct = default)
        {
            var resp = await _http.GetAsync(url, ct);
            resp.EnsureSuccessStatusCode();
            return await resp.Content.ReadFromJsonAsync<T>(cancellationToken: ct);
        }
    }
}
