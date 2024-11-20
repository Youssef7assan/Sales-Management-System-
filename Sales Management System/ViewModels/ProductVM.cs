using Sales_Management_System.Models;

namespace Sales_Management_System.ViewModels
{
	public class ProductVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }

		public int SupplierID { get; set; }

		public string? ImageUrl { get; set; }



		public int CategoryID { get; set; }

		public List<Category>? categoryList { get; set; }
		public List<Supplier>? SupplierList { get; set; }
	}
}
