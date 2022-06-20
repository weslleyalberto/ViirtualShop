using System.ComponentModel.DataAnnotations;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="O {0} é obrigatório!")]
        [MinLength(3,ErrorMessage ="{0} deve ter no mínimo {1} caracteres!")]
        [MaxLength(100,ErrorMessage ="{0} deve conter no máximo {1} caracteres!")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [MinLength(5, ErrorMessage = "{0} deve ter no mínimo {1} caracteres!")]
        [MaxLength(200, ErrorMessage = "{0} deve conter no máximo {1} caracteres!")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [Range(1,9999,ErrorMessage ="{0} deve estar entre {1}  e {2}")]
        public long Stock { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
