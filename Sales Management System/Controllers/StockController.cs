using Microsoft.AspNetCore.Mvc;
using Sales_Management_System.Models;
using Sales_Management_System.Repository;
using Sales_Management_System.ViewModels;

namespace Sales_Management_System.Controllers
{
	public class StockController : Controller
	{
		private readonly IStockRepository stockRepository;
		private readonly IProductRepository productRep;
		private readonly IStoreRepository storeRep;

		public StockController(IStockRepository stockRepository, IProductRepository product, IStoreRepository store)
		{
			this.stockRepository = stockRepository;
			this.productRep = product;
			this.storeRep = store;
		}
		[HttpGet]
		public IActionResult Index()
		{
			List<Stock> stocks = stockRepository.GetAll();

			return View("Index", stocks);
		}
		[HttpGet]
		public IActionResult Add()
		{

			List<Product> productList = productRep.GetAll();
			List<Store> storesList = storeRep.GetAll();
			StockVM stockVM = new StockVM();
			stockVM.ProductList = productList;
			stockVM.storeList = storesList;

			return View("Add", stockVM);

		}
		[HttpPost]
		public IActionResult SaveAdd(StockVM stockFromReq)
		{
			Stock stockDb = new Stock();
			if (stockFromReq == null)
			{
				return View("Error");
			}
			if (ModelState.IsValid)
			{
				stockDb.Quantity = stockFromReq.Quantity;
				stockDb.ProductID = stockFromReq.ProductID;
				stockDb.StoreID = stockFromReq.StoreID;
				stockRepository.Add(stockDb);
				stockRepository.save();
				return RedirectToAction("Index");
			}
			List<Product> products = productRep.GetAll();
			List<Store> storeList = storeRep.GetAll();
			stockFromReq.storeList = storeList;
			stockFromReq.ProductList = products;
			return View("Add", stockFromReq);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			StockVM stockVM = new StockVM();
			Stock stock = stockRepository.GetById(id);
			stockVM.Quantity = stock.Quantity;
			stockVM.ProductID = stock.ProductID;
			stockVM.StoreID = stock.StoreID;
			List<Product> products = productRep.GetAll();
			List<Store> stores = storeRep.GetAll();
			stockVM.ProductList = products;
			stockVM.storeList = stores;
			return View("Edit", stockVM);
		}

		[HttpPost]
		public IActionResult SaveEdit(int id, StockVM stockFromRequest)
		{
			Stock stockDb = stockRepository.GetById(id);
			if (ModelState.IsValid)
			{
				stockDb.ProductID = stockFromRequest.ProductID;
				stockDb.Quantity = stockFromRequest.Quantity;
				stockDb.StoreID = stockFromRequest.StoreID;
				stockRepository.Update(stockDb);
				stockRepository.save();
				return RedirectToAction("Index");
			}
			return View("Edit", stockFromRequest);

		}
		[HttpGet]
		public IActionResult Details(int id)
		{
			StockVM stockVM =new StockVM();
			Stock stock = stockRepository.GetById(id);
			var Name= productRep.GetById(stock.ProductID);
			stockVM.Quantity = stock.Quantity;
			stockVM.ProductID = stock.ProductID;
			stockVM.StoreID= stock.StoreID;
			stockVM.ProductName = Name != null ? $"{Name.Name}" : "Unknown";

			return View("Details", stockVM);
		}
		public IActionResult Delete(int id)
		{

			stockRepository.Delete(id);
			stockRepository.save();
			return RedirectToAction("Index");

		}
	}
}
