using Microsoft.AspNetCore.Mvc;
using Sales_Management_System.Models; // تعديل المسار حسب مشروعك
using Sales_Management_System.Repository;
using Sales_Management_System.ViewModels;

public class CartController : Controller
{
	public CartController(IProductRepository product, AppDbContext context)
	{
		this.product = product;
		this._context = context;
	}
	private const string CartSessionKey = "Cart"; // اسم المفتاح المستخدم في السيشن
	private readonly IProductRepository product;
	private readonly AppDbContext _context;

	public IActionResult Index()
	{
		// جلب بيانات الكارت من السيشن
		var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
		return View(cart);
	}

	[HttpPost]
	public IActionResult AddToCart(int productId)
	{
		// جلب بيانات الكارت من السيشن
		var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

		// البحث عن المنتج في الكارت
		var existingItem = cart.FirstOrDefault(c => c.Product.Id == productId);

		if (existingItem != null)
		{
			existingItem.Quantity++;
		}
		else
		{
			// جلب المنتج من قاعدة البيانات
			var product = _context.Products.FirstOrDefault(p => p.Id == productId); // افترض أن لديك DbContext باسم _context
			if (product != null)
			{
				cart.Add(new CartItem
				{
					Product = product,
					Quantity = 1
				});
			}
		}

		// تحديث بيانات الكارت في السيشن
		HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
		return RedirectToAction("Index");
	}

	[HttpPost]
	public IActionResult RemoveFromCart(int productId)
	{
		var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
		var item = cart.FirstOrDefault(c => c.Product.Id == productId);
		if (item != null)
		{
			cart.Remove(item);
		}

		HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
		return RedirectToAction("Index");
	}

	[HttpPost]
	public IActionResult UpdateQuantity(int productId, int quantity)
	{
		var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
		var item = cart.FirstOrDefault(c => c.Product.Id == productId);
		if (item != null)
		{
			item.Quantity = quantity > 0 ? quantity : 1;
		}

		HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
		return RedirectToAction("Index");
	}
	public IActionResult Checkout()
	{
		var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

		if (!cart.Any())
		{
			return RedirectToAction("Index", "Cart");
		}

		var model = new CheckoutViewModel
		{
			CartItems = cart,
			TotalAmount = cart.Sum(item => item.Product.Price * item.Quantity)
		};

		return View(model);
	}

	// معالجة الطلب عند الدفع
	[HttpPost]
	public IActionResult Checkout(CheckoutViewModel model)
	{
		if (ModelState.IsValid)
		{
			// هنا يمكنك إضافة كود لتخزين الطلب في قاعدة البيانات، معالجة الدفع، إلخ.
			// بمجرد أن يتم الدفع بنجاح، نقوم بتفريغ الكارت.

			HttpContext.Session.Remove(CartSessionKey);  // تفريغ الكارت من السيشن بعد إتمام الدفع.

			return RedirectToAction("OrderConfirmation");
		}

		return View(model);
	}

	public IActionResult OrderConfirmation()
	{
		return View();
	}
}
