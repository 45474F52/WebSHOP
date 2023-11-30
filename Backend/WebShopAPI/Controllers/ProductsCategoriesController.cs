using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Models.Data;
using WebShopAPI.Models.DTO;

namespace WebShopAPI.Controllers
{
    [ApiController]
    [Route("categories")]
    public sealed class ProductsCategoriesController : ControllerBase
    {
        private readonly ShopDataContext _db;

        public ProductsCategoriesController(ShopDataContext dataContext) => _db = dataContext;

        [HttpGet]
        public ActionResult<IEnumerable<ProductCategory>> GetAll()
        {
            var list = _db.ProductCategories.Include(pc => pc.Products).Select(pc => pc.ToDTO()).ToList();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ProductCategoryDTO> GetById(int id)
        {
            ProductCategory? target = _db.ProductCategories.Find(id);
            if (target == null)
                return NoContent();
            return Ok(target.ToDTO());
        }
    }
}
