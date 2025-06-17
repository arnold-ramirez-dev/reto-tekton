namespace Reto.Shared
{
    public class RZResponse<T>
    {
        public bool IsSuccess { get; }
        public string? Message { get; }
        public T? Data { get; }

        private RZResponse(bool isSuccess, string? message, T? data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public static RZResponse<T> Success(T data, string? message = null) => new(true, message, data);

        public static RZResponse<T> Failure(string message) => new(false, message, default);
    }
}
