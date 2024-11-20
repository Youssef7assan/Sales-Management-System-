using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Management_System.Models
{
	public class Order
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Order date is required.")]
		[DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
		public DateTime? OrderDate { get; set; }

		[Required(ErrorMessage = "Total amount is required.")]
		[Range(0.01, double.MaxValue, ErrorMessage = "Total amount must be a positive value.")]
		public decimal TotalAmount { get; set; }

		public bool IsPaid { get; set; }

		[Required(ErrorMessage = "Customer ID is required.")]
		[ForeignKey("customers")]
		public int CustomerID { get; set; }
		public Customer customers { get; set; }

		[Required(ErrorMessage = "Order status is required.")]
		public StatusOrder Status { get; set; }

		public List<OrderDetail>? OrderDetails { get; set; }
		public List<Credit>? credits { get; set; }

	}
}
