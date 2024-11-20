using Sales_Management_System.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales_Management_System.ViewModels
{
	public class OrderViewModel
	{
		public int Id { get; set; }
		public DateTime? OrderDate { get; set; }
		public decimal TotalAmount { get; set; }
		public bool IsPaid { get; set; }
		[Display(Name ="Customer Name")]
		public string? CustomerName { get; set; }
		public int CustomerID { get; set; }
		public List<Customer>? CustomersList { get; set; }
		public StatusOrder Status { get; set; }
	}
}
