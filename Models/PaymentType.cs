using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
        public string? Type { get; set; }
        public string? Details { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}