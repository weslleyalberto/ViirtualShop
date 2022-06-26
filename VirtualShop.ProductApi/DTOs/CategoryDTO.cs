using System.ComponentModel.DataAnnotations;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [MinLength(3, ErrorMessage = "{0} deve ter no mínimo {1} caracteres!")]
        [MaxLength(100, ErrorMessage = "{0} deve conter no máximo {1} caracteres!")]
        public string? Name { get; set; }
        public  ICollection<Product>? Products { get; set; }
    }
}
