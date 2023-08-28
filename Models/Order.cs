using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bangazon.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public List<Product>? Products { get; set; }
        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        [ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }
        public PaymentType? PaymentType { get; set; }
    }
}