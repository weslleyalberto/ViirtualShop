using Microsoft.AspNetCore.Mvc;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Services;

namespace VirtualShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get([FromServices]ICategoryService categoryService)
        {
            var categoriesDTO = await categoryService.GetCategories();
            if(categoriesDTO is null)
            {
                return NotFound("Categorias não encontradas");
            }
            return Ok(categoriesDTO);
        }
        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriasProduct([FromServices]ICategoryService categoryService)
        {
            var categoriesDTO = await categoryService.GetCategoriesProducts();
            if (categoriesDTO == null)
            {
                return NotFound("Categoria de produtos nao encontrada");
            }
            
            else
            {
                return Ok(categoriesDTO);
            }
          

        }
        [HttpGet("{id:int}",Name ="GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get([FromServices]ICategoryService categoryService, int id)
        {
            var categoriesDTO = await categoryService.GetCategoryById(id);
            if (categoriesDTO is null)
                return NotFound("Categoria não encontrada");
            else
                return Ok(categoriesDTO);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromServices]ICategoryService categoryService, [FromBody]CategoryDTO categoryDTO)
        {
            if (categoryDTO is null)
                return BadRequest("Invalid Data");
            await categoryService.AddCategory(categoryDTO);
            return new CreatedAtRouteResult("GetCategory", new {id = categoryDTO.CategoryId},categoryDTO);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromServices]ICategoryService categoryService,int id, [FromBody]CategoryDTO categoryDTO)
        {
            if(id != categoryDTO.CategoryId)
                return BadRequest();
            if (categoryDTO is null)
                return BadRequest();
            await categoryService.UpdateCategory(categoryDTO);
            return Ok(categoryDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete([FromServices]ICategoryService categoryService,int id)
        {
            var categoriaDTO = await categoryService.GetCategoryById(id);
            if (categoriaDTO is null)
                return NotFound("Categoria nao encontrada");
            await categoryService.RemoveCategory(id);
            return Ok(categoriaDTO);    
        }
        
    }
}
