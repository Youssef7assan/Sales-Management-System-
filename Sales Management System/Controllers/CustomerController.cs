using Microsoft.AspNetCore.Mvc;
using Sales_Management_System.Models;
using Sales_Management_System.Repository;

namespace Sales_Management_System.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ICustomerRepository repository;

		public CustomerController(ICustomerRepository repository)
		{
			this.repository = repository;
		}
		[HttpGet]
		public IActionResult Index()
		{
			List<Customer> customer = repository.GetAll();
			return View(customer);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View("Add");
		}
		[HttpPost]
		public IActionResult SaveAdd(Customer customer)
		{
			if (ModelState.IsValid)
			{
				repository.Add(customer);
				repository.save();
				return RedirectToAction("Index");
			}
			return View("Add", customer);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			Customer customer = repository.GetById(id);
			return View("Edit", customer);
		}

		[HttpPost]

		public IActionResult SaveEdit(int id, Customer customer)
		{
			Customer CustomerDb = repository.GetById(id);
		
			
			if (ModelState.IsValid)
			{
				
				CustomerDb.Fname = customer.Fname;
				CustomerDb.Lname = customer.Lname;
				CustomerDb.Address = customer.Address;
				CustomerDb.Phone = customer.Phone;
				repository.Update(CustomerDb);
				repository.save();
				return RedirectToAction("Index");
			}

			return View("Edit", customer);
		}
		

		public IActionResult Delete(int id)
		{

			repository.Delete(id);
			repository.save();
			return RedirectToAction("Index");
		}

	}
}
