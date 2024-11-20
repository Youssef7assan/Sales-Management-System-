using Microsoft.EntityFrameworkCore;
using Sales_Management_System.Models;
using Sales_Management_System.Repository;

namespace Sales_Management_System
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<AppDbContext>(options =>
			{

				options.UseSqlServer(builder.Configuration.GetConnectionString("Sales"));
			});

			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<IOrderRepository, OrderRepository>();
			builder.Services.AddScoped<IStockRepository, StockRepository>();
			builder.Services.AddScoped<IStoreRepository, StoreRepository>();
			builder.Services.AddScoped<ICreditRepository, CreditRepository>();
			builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
			builder.Services.AddScoped<ISuppliersRepository, SuppliersRepository>();


			builder.Services.AddDistributedMemoryCache();  // ????? ??????? ???????? ?????
			builder.Services.AddSession();  // ????? ??????


			var app = builder.Build();

			app.UseSession();


			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
