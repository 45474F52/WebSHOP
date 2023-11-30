using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopAPI.Models.Data;
using WebShopAPI.Models.DTO;

namespace WebShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class ProductsController : ControllerBase
    {
        private readonly ShopDataContext _db;

        public ProductsController(ShopDataContext dataContext) => _db = dataContext;

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetAll()
        {
            var list = _db.Products.Include(p => p.Category).Select(p => p.ToDTO()).ToList();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ProductDTO> GetById(int id)
        {
            Product? target = _db.Products.Find(id);

            if (target == null)
                return NoContent();

            _db.Entry(target).Reference(p => p.Category).Load();
            var dto = target.ToDTO();

            return Ok(dto);
        }
    }
}
