using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class Order_Product
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }

    }
}