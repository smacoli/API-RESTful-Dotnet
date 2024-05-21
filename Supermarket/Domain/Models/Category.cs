namespace Supermarket.Domain.Models
{
    /// <summary>
    /// Classe da categoria dos produtos do supermercado, possui relacionamento 1:n com produtos
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> products { get; set; } = new();
    }
}
