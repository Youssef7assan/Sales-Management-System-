namespace Sales_Management_System.Models
{
	public class CartItem
	{
		public Product Product { get; set; } // المنتج المرتبط بالكارت
		public int Quantity { get; set; } // الكمية المطلوبة
	}
}
