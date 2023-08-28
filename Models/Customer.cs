using System.ComponentModel.DataAnnotations;

namespace Bangazon.Models
{
	public class Customer
	{
		[Key]
		public int CustomerId { get; set; }
		public string? Username { get; set; }
		public List<Product>? Cart { get; set; }
		public List<PaymentType>? PaymentTypes { get; set; }
		public List<Order>? OrderHistory { get; set; }
	}
}