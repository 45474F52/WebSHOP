using System.ComponentModel.DataAnnotations;

namespace WebShopAPI.Models.DTO
{
    public sealed record ProductInOrderDTO
    {
        [Required]
        public int Id { get; init; }
        [Required]
        public required string Name { get; init; }
        public string? Manufacturer { get; init; }
        [Required]
        public required decimal Price { get; init; }
        [Required]
        public required ProductCategoryDTO Category { get; init; }
    }
}
