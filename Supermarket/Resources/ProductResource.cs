namespace Supermarket.Resources
{
    public class ProductResource
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int QuantityInPackage { get; set; }
        public required string UnitOfMeasurement { get; set; }
        public CategoryResource Category { get; set; }
    }
}
