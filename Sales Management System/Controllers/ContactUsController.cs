using Microsoft.AspNetCore.Mvc;
using Sales_Management_System.Models;

namespace Sales_Management_System.Controllers
{
	public class ContactUsController : Controller
	{
		AppDbContext _context;
		public ContactUsController(AppDbContext appDbContext)
		{
			_context = appDbContext;
		}
		[HttpGet]
		public IActionResult Index()
		{
			List<ContactUs> contactUs = _context.ContactUs.ToList();
			return View("Index", contactUs);
		}
		[HttpGet]
		public IActionResult Add()
		{

			return View("Add");
		}
		[HttpPost]
		public IActionResult SaveAdd(ContactUs contactUs)
		{
			if (ModelState.IsValid)
			{
				_context.ContactUs.Add(contactUs);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("add", contactUs);
		}
		public IActionResult Delete(int id)
		{
			ContactUs contactUs = _context.ContactUs.FirstOrDefault(p => p.Id == id);
			_context.Remove(contactUs);
			_context.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
