using System.ComponentModel.DataAnnotations;

namespace Sales_Management_System.Models
{
	public class Store
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Location is required")]
		public string Location { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Capasity must be a positive number")]
		public int? Capasity { get; set; }

		public List<Stock>? Stocks { get; set; }
	}
}
