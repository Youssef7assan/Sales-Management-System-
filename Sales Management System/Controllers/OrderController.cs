using Microsoft.AspNetCore.Mvc;
using Sales_Management_System.Models;
using Sales_Management_System.Repository;
using Sales_Management_System.ViewModels;

namespace Sales_Management_System.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderRepository repository;
		private readonly ICustomerRepository customerRepository;

		public OrderController(IOrderRepository repository, ICustomerRepository customerRepository)
		{
			this.repository = repository;
			this.customerRepository = customerRepository;
		}


		public IActionResult Index()
		{
			List<Order> orders = repository.GetAll();
			return View("Index", orders);
		}

		[HttpGet]
		public IActionResult Add()
		{
			OrderViewModel orderViewModel = new OrderViewModel();

			List<Customer> CustomersList = customerRepository.GetAll();
			orderViewModel.CustomersList = CustomersList;

			return View("Add", orderViewModel);

		}
		[HttpPost]
		public IActionResult SaveAdd(OrderViewModel orderFromRequest)
		{
			Order OrderDB = new Order();
			if (ModelState.IsValid)
			{
				OrderDB.TotalAmount = orderFromRequest.TotalAmount;
				OrderDB.Status = orderFromRequest.Status;
				OrderDB.OrderDate = orderFromRequest.OrderDate;
				OrderDB.IsPaid = orderFromRequest.IsPaid;
				OrderDB.CustomerID = orderFromRequest.CustomerID;
				repository.Add(OrderDB);
				repository.save();
				return RedirectToAction("Index");
			}
			List<Customer> customers = customerRepository.GetAll();
			orderFromRequest.CustomersList = customers;
			return View("Add", orderFromRequest);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			OrderViewModel orderViewModel = new OrderViewModel();
			Order order = repository.GetById(id);
			orderViewModel.OrderDate = order.OrderDate;
			orderViewModel.Status = order.Status;
			orderViewModel.CustomerID = order.CustomerID;
			orderViewModel.IsPaid = order.IsPaid;
			orderViewModel.TotalAmount = order.TotalAmount;
			List<Customer> customerList = customerRepository.GetAll();
			orderViewModel.CustomersList = customerList;
			return View("Edit", orderViewModel);
		}
		public IActionResult Details(int id)
		{
			OrderViewModel orderViewModel = new OrderViewModel();
			Order order = repository.GetById(id);
			var customer = customerRepository.GetById(order.CustomerID); // الحصول على تفاصيل العميل

			orderViewModel.CustomerID = order.CustomerID;
			orderViewModel.Status = order.Status;
			orderViewModel.IsPaid = order.IsPaid;
			orderViewModel.OrderDate = order.OrderDate;
			orderViewModel.TotalAmount = order.TotalAmount;

			// تعيين اسم العميل
			orderViewModel.CustomerName = customer != null ? $"{customer.Fname} {customer.Lname}" : "Unknown";

			return View("Details", orderViewModel);
		}


		[HttpPost]
		public IActionResult SaveEdit(int id, OrderViewModel orderFromRequest)
		{
			Order orderDb = repository.GetById(id);

			if (ModelState.IsValid)
			{
				orderDb.Status = orderFromRequest.Status;
				orderDb.OrderDate = orderFromRequest.OrderDate;
				orderDb.CustomerID = orderFromRequest.CustomerID;
				orderDb.IsPaid = orderFromRequest.IsPaid;
				orderDb.TotalAmount = orderFromRequest.TotalAmount;
				repository.Update(orderDb);
				repository.save();
				return RedirectToAction("Index");
			}

			List<Customer> orders = customerRepository.GetAll();
			orderFromRequest.CustomersList = orders;
			return View("Edit", orderFromRequest);
		}


		public IActionResult Delete(int id)
		{
			Order order = repository.GetById(id);
			repository.Delete(id);
			repository.save();
			return RedirectToAction("Index");
		}
	}
}
