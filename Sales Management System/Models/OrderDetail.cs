using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Management_System.Models
{
	public class OrderDetail
	{
		public int ID { get; set; }

		public int Quantity { get; set; }
		public decimal? UnitPrice { get; set; }

		[ForeignKey("Order")]
		public int OrderID { get; set; }
		public Order Order { get; set; }

		[ForeignKey("Product")]
		public int ProductID { get; set; }
		public Product Product { get; set; }
	}
}
