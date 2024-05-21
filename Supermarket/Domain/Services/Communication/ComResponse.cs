namespace Supermarket.Domain.Services.Communication
{
    public record ComResponse<T>
    {
        public bool Success { get; init; }
        public string? Message { get; init; }
        public T? Resource { get; init; }

        public ComResponse(T resource)
        {
            Success = true;
            Message = null;
            Resource = resource;
        }

        public ComResponse(string message)
        {
            Success = false;
            Message = message;
            Resource = default;
        }
    }
}
