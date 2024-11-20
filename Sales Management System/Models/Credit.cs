using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Management_System.Models
{
	public class Credit
	{
		public int Id { get; set; }
		public decimal AmountDue { get; set; }
		public DateTime? DueDate { get; set; }
		public StatusOrder StatusOrder { get; set; }
		[ForeignKey("customers")]
		public int CustomerID { get; set; }
		public Customer customers { get; set; }
		[ForeignKey("orders")]
		public int OrderID { get; set; }
		public Order orders { get; set; }
	}
}
