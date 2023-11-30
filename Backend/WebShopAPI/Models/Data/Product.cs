namespace WebShopAPI.Models.Data
{
    public record Product
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public string? Image {  get; init; }
        public string? Manufacturer { get; init; }
        public decimal Price { get; init; }

        public virtual required ProductCategory Category { get; init; }
    }
}
