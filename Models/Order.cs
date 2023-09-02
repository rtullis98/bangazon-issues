using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public List<Product>? Products { get; set; }
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType? PaymentType { get; set; }
        public ICollection<Order_Product>? Ordered_Products { get; set; }
    }
}