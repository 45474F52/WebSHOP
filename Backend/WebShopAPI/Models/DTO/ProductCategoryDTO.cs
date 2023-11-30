using System.ComponentModel.DataAnnotations;

namespace WebShopAPI.Models.DTO
{
    public sealed record ProductCategoryDTO
    {
        [Required]
        public int Id { get; init; }
        [Required]
        public required string Name { get; init; }
    }
}
