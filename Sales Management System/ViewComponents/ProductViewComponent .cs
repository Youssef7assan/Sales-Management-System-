using Microsoft.AspNetCore.Mvc;
using Sales_Management_System.Models;

namespace Sales_Management_System.ViewComponents
{
	public class ProductViewComponent : ViewComponent
	{

		private readonly AppDbContext _context;

		public ProductViewComponent(AppDbContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			// جلب المنتجات من قاعدة البيانات
			var products = _context.Products.ToList();
			return View(products);
		}
	}
}
