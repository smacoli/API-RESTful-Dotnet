namespace Supermarket.Resources
{
    public class QueryResultResource<T>
    {
        public required int TotalItems { get; init; } = 0;
        public required List<T> Items { get; init; } = new();
    }
}
