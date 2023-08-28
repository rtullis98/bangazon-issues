using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public string? StoreName { get; set; }
        public List<Product>? Products { get; set; }
    }
}