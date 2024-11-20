using Microsoft.AspNetCore.Mvc;
using Sales_Management_System.Models;
using Sales_Management_System.Repository;

namespace Sales_Management_System.Controllers
{
	public class StoreController : Controller
	{
		private readonly IStoreRepository storeRepository;

		public StoreController(IStoreRepository storeRepository)
		{
			this.storeRepository = storeRepository;
		}
		public IActionResult Index()
		{
			List<Store> stores = storeRepository.GetAll();
			return View("Index", stores);
		}
		public IActionResult Add()
		{
			return View("Add");
		}
		public IActionResult SaveAdd(Store storeFromReq)
		{
			if (ModelState.IsValid)
			{
				storeRepository.Add(storeFromReq);
				storeRepository.save();
				return RedirectToAction("Index");
			}
			return View("Add", storeFromReq);
		}
		public IActionResult Edit(int id)
		{
			Store store = storeRepository.GetById(id);
			return View("Edit", store);

		}
		public IActionResult SaveEdit(int id, Store storeFromReq)
		{

			Store store = storeRepository.GetById(id);
			if (ModelState.IsValid)
			{
				store.Location = storeFromReq.Location;
				store.Capasity = storeFromReq.Capasity;
				storeRepository.Update(store);
				storeRepository.save();
				return RedirectToAction("Index");
			}
			return View("Edit", storeFromReq);
		}
		public IActionResult Delete(int id)
		{
			storeRepository.Delete(id);
			storeRepository.save();
			return RedirectToAction("Index");
		}
		public IActionResult Details(int id)
		{
			Store store = storeRepository.GetById(id);
			return View("Details", store);
		}
	}
}
