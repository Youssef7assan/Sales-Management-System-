using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Management_System.Models
{
	public class Stock
	{
		public int Id { get; set; }
		public int Quantity { get; set; }
		[ForeignKey("products")]
		public int ProductID { get; set; }
		public Product products { get; set; }

		[ForeignKey("store")]
		public int StoreID { get; set; }
		public Store store { get; set; }

	}
}
