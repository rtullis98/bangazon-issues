using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int QuantityAvailable { get; set; }
        public decimal PricePerUnit { get; set; }
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public ICollection<Order_Product>? Ordered_Products { get; set; }

    }
}