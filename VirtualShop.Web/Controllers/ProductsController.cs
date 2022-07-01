using Microsoft.AspNetCore.Mvc;
using VirtualShop.Web.Models;

namespace VirtualShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index([FromServices] Services.IProductService productService)
        {
            var resul = await productService.GetAllProduct();
            if (resul is null)
                return View("Error");
            return View(resul);
        }
    }
}
