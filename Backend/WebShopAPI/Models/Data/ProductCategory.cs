namespace WebShopAPI.Models.Data
{
    public record ProductCategory
    {
        public ProductCategory() => Products = new HashSet<Product>();

        public int Id { get; init; }
        public required string Name { get; init; }

        public virtual ICollection<Product> Products { get; init; }
    }
}
