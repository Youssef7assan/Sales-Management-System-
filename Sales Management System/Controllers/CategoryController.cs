using Microsoft.AspNetCore.Mvc;
using Sales_Management_System.Models;
using Sales_Management_System.Repository;

namespace Sales_Management_System.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryRepository repository;

		public CategoryController(ICategoryRepository repository)
		{
			this.repository = repository;
		}
		public IActionResult Index()
		{
			List<Category> category = repository.GetAll();
			return View(category);
		}
		public IActionResult Add()
		{
			return View("Add");
		}
		public IActionResult SaveAdd(Category category)
		{
			if (ModelState.IsValid)
			{
				repository.Add(category);
				repository.save();
				return RedirectToAction("Index");
			}
			return View("Add", category);

		}
		public IActionResult Edit(int id)
		{
			Category category = repository.GetById(id);
			return View("Edit", category);
		}
		public IActionResult SaveEdit(Category category, int id)
		{
			
			var categoryDb = repository.GetById(id);

		
			if (categoryDb == null)
			{
				
				return NotFound(); 
			}

			
			if (ModelState.IsValid)
			{
				
				categoryDb.CategoryName = category.CategoryName;

				
				repository.Update(categoryDb);
				repository.save();

			
				return RedirectToAction("Index");
			}

			
			return View("Edit", category);
		}

		public IActionResult Delete(int id)
		{
			repository.Delete(id);
			repository.save();
			return RedirectToAction("Index");
		}
	}
}
