using Sales_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Sales_Management_System.ViewModels
{
	public class StockVM
	{
		public int Id { get; set; }
		public int Quantity { get; set; }

		public int ProductID { get; set; }
		public List<Product>? ProductList { get; set; }
		[Display(Name ="Product Name")]
		public string? ProductName { get; set; }
		public int StoreID { get; set; }
		public List<Store>? storeList { get; set; }

	}
}
