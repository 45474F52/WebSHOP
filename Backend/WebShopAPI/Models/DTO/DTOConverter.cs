using WebShopAPI.Models.Data;

namespace WebShopAPI.Models.DTO
{
    public static class DTOConverter
    {
        public static ProductCategoryDTO ToDTO(this ProductCategory productCategory)
        {
            return new ProductCategoryDTO
            {
                Id = productCategory.Id,
                Name = productCategory.Name
            };
        }

        public static ProductDTO ToDTO(this Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                Manufacturer = product.Manufacturer,
                Price = product.Price,
                Category = product.Category.ToDTO()
            };
        }
    }
}
