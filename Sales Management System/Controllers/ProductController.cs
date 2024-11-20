using Microsoft.AspNetCore.Mvc;
using Sales_Management_System.Models;
using Sales_Management_System.Repository;
using Sales_Management_System.ViewModels;

namespace Sales_Management_System.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductRepository productRepository;
		private readonly ICategoryRepository categoryRepository;
		private readonly ISuppliersRepository suppliersRepository;

		public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, ISuppliersRepository suppliersRepository)
		{
			this.productRepository = productRepository;
			this.categoryRepository = categoryRepository;
			this.suppliersRepository = suppliersRepository;
		}
		[HttpGet]
		public IActionResult ProductMain()
		{
			List<Product> products = productRepository.GetAll();
			return View("ProductMain", products);
		}
		public IActionResult Index()
		{
			List<Product> products = productRepository.GetAll();
			return View("Index", products);
		}
		[HttpGet]
		public IActionResult Add()
		{
			ProductVM productsVM = new ProductVM();

			List<Category> categorylist = categoryRepository.GetAll();
			List<Supplier> suppliersList = suppliersRepository.GetAll();

			productsVM.SupplierList = suppliersList;
			productsVM.categoryList = categorylist;

			return View(productsVM);
		}
		[HttpPost]
		public IActionResult SaveAdd(ProductVM productVM)
		{
			if (ModelState.IsValid)
			{
				Product product = new Product();
				product.Name = productVM.Name;
				product.Description = productVM.Description;
				product.Price = productVM.Price;
				product.Quantity = productVM.Quantity;
				product.SupplierID = productVM.SupplierID;
				product.CategoryID = productVM.CategoryID;


				productRepository.Add(product);
				productRepository.save();
				return RedirectToAction("Index", "Home");
			}
			return View(productVM);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			Product product = productRepository.GetById(id);
			ProductVM productsVM = new ProductVM();

			List<Category> categorylist = categoryRepository.GetAll();
			List<Supplier> suppliersList = suppliersRepository.GetAll();
			productsVM.Id = product.Id;
			productsVM.SupplierList = suppliersList;
			productsVM.categoryList = categorylist;
			productsVM.Name = product.Name;
			productsVM.Description = product.Description;
			productsVM.Price = product.Price;
			productsVM.Quantity = product.Quantity;
			productsVM.CategoryID = product.CategoryID;
			productsVM.SupplierID = product.SupplierID;
			return View("Edit", productsVM);

		}
		[HttpPost]
		public IActionResult SaveEdit(int id, ProductVM productFromReqoest)
		{
			Product product = productRepository.GetById(id);
			if (ModelState.IsValid)
			{
				product.Name = productFromReqoest.Name;
				product.Price = productFromReqoest.Price;
				product.Quantity = productFromReqoest.Quantity;
				product.SupplierID = productFromReqoest.SupplierID;
				product.CategoryID = productFromReqoest.CategoryID;
				product.Description = productFromReqoest.Description;
				productRepository.Update(product);
				productRepository.save();
				return RedirectToAction("Index", "Home");

			}
			return View("Edit", productFromReqoest);
		}
		[HttpPost]
		public IActionResult Delete(int id)
		{
			try
			{
				// استدعاء طريقة حذف المنتج
				productRepository.Delete(id);
				return RedirectToAction("Index", "Home");

			}
			catch (Exception ex)
			{
				// التعامل مع الخطأ إذا حدث
				return BadRequest(ex.Message);
			}

		}
		public IActionResult Details(int id)
		{
			Product product = productRepository.GetById(id);
			return View("Details", product);
		}
	}
}
