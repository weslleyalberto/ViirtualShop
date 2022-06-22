using Microsoft.AspNetCore.Mvc;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Services;

namespace VirtualShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get([FromServices]IProductService productService)
        {
            var produtoDto = await productService.GetProducts();
            if (produtoDto is null)
                return NotFound("Produto nao localizado!");
            return Ok(produtoDto);  
        }
        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get([FromServices]IProductService productService, int id)
        {
            var produtoDto = await productService.GetProductById(id);
            if (produtoDto is null)
                return NotFound("Produto não encontrado");
            return Ok(produtoDto);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromServices]IProductService productService, [FromBody]ProductDTO productDTO)
        {
            if (productDTO is null)
                return BadRequest("Data invalida!");
            await productService.AddProduct(productDTO);
            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
            
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromServices]IProductService productService,int id, [FromBody]ProductDTO productDTO)
        {
            if (id != productDTO.Id)
                return BadRequest("Data invalid!");
            if (productDTO is null)
                return BadRequest("Data invalid!");

            await productService.UpdateProduct(productDTO);
            return Ok(productDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromServices]IProductService productService, int id)
        {
            var produtoDto = await productService.GetProductById(id);
            if (produtoDto is null)
                return NotFound("Produto não encontrado!");

            await productService.RemoveProduct(id);
            return Ok(produtoDto);  
        }
    }
}
