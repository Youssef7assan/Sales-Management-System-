using Microsoft.AspNetCore.Mvc;
using Sales_Management_System.Models;
using Sales_Management_System.Repository;

namespace Sales_Management_System.Controllers
{
	public class SupplierController : Controller
	{
		private readonly ISuppliersRepository suppliersRepository;

		public SupplierController(ISuppliersRepository suppliersRepository)
		{
			this.suppliersRepository = suppliersRepository;
		}
		public IActionResult Index()
		{
			List<Supplier> suppliers = suppliersRepository.GetAll();
			return View("Index", suppliers);
		}
		public IActionResult Add()
		{
			return View("Add");
		}
		public IActionResult SaveAdd(Supplier supplierFromReq)
		{
			if (ModelState.IsValid)
			{
				suppliersRepository.Add(supplierFromReq);
				suppliersRepository.save();
				return RedirectToAction("Index");
			}
			return View("Add", supplierFromReq);
		}
		public IActionResult Delete(int id)
		{
			Supplier supplier = suppliersRepository.GetById(id);
			suppliersRepository.Delete(id);
			suppliersRepository.save();
			return RedirectToAction("Index");
		}
		public IActionResult Edit(int id)
		{
			Supplier supplier = suppliersRepository.GetById(id);
			return View(supplier);
		}

		public IActionResult SaveEdit(int id, Supplier supplierFromReq)
		{
			Supplier supplierDb = suppliersRepository.GetById(id);
			if (supplierDb.Name != null && supplierDb.Phone != null)
			{
				supplierDb.Phone = supplierFromReq.Phone;
				supplierDb.Name = supplierFromReq.Name;
				suppliersRepository.Update(supplierDb);
				suppliersRepository.save();
				return RedirectToAction("Index");
			}
			return View("Edit", supplierFromReq);
		}
		public IActionResult Details(int id)
		{
			Supplier supplier = suppliersRepository.GetById(id);
			return View("Details", supplier);
		}
	}
}
