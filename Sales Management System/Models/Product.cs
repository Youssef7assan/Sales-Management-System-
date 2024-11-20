using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Management_System.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public string? ImageUrl { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		[ForeignKey("suppliers")]
		public int SupplierID { get; set; }

		public Supplier suppliers { get; set; }

		[ForeignKey("category")]
		public int CategoryID { get; set; }
		public Category category { get; set; }
		public List<Stock>? stocks { get; set; }
		public List<OrderDetail>? orderDetails { get; set; }

	}
}
