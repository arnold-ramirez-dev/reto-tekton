namespace Reto.Domain.Interfaces
{
    public interface IHttpRequester
    {
        Task<T?> GetAsync<T>(string relativeUrl, CancellationToken ct = default);
    }
}
