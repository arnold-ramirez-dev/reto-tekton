namespace Reto.Domain.Interfaces
{
    public interface IStatusCache
    {
        IReadOnlyDictionary<int, string> GetAll();
    }
}
