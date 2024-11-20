using Microsoft.EntityFrameworkCore;

namespace Sales_Management_System.Models
{
	public class AppDbContext : DbContext
	{
		public DbSet<ContactUs> ContactUs { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<Store> Stores { get; set; }
		public DbSet<Stock> Stocks { get; set; }
		public DbSet<Credit> credits { get; set; }
		public DbSet<Customer> customers { get; set; }


		public AppDbContext(DbContextOptions options) : base(options)
		{

		}
	}
}
