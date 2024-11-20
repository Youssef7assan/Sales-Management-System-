using Microsoft.AspNetCore.Mvc;
using Sales_Management_System.Models;
using Sales_Management_System.Repository;
using System.Diagnostics;

namespace Sales_Management_System.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IProductRepository productRepository;

		public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
		{
			_logger = logger;
			this.productRepository = productRepository;
		}

		public IActionResult Index()
		{


			return View();
		}


		public IActionResult Privacy()
		{
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
