using Sales_Management_System.Models;

namespace Sales_Management_System.ViewModels
{
	public class CheckoutViewModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string PhoneNumber { get; set; }
		public string PaymentMethod { get; set; }
		public decimal TotalAmount { get; set; }

		public List<CartItem> CartItems { get; set; }
	}
}
