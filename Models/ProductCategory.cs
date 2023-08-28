using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}