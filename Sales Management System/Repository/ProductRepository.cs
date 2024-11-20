using Microsoft.EntityFrameworkCore;
using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public class ProductRepository:IProductRepository
	{
		AppDbContext _appDbContext;
		public ProductRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public void Add(Product product)
		{
			_appDbContext.Products.Add(product);
		}

		public List<Product> GetAll()
		{
			List<Product> result = _appDbContext.Products.Include(p=>p.suppliers).Include(o=>o.category).ToList();
			return result;
		}

		public Product GetById(int id)
		{
			Product product = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
			return product;
		}

		public void Delete(int Id)
		{
			// التحقق من السجلات في المخزون أولاً
			var stockRecords = _appDbContext.Stocks.Where(s => s.ProductID == Id).ToList();

			if (stockRecords.Any())
			{
				// حذف السجلات المتعلقة بالمنتج من المخزون
				_appDbContext.Stocks.RemoveRange(stockRecords);
			}

			// التحقق من وجود المنتج وحذفه بعد حذف السجلات في المخزون
			var product = _appDbContext.Products.Find(Id);
			if (product != null)
			{
				_appDbContext.Products.Remove(product);
				_appDbContext.SaveChanges();
			}
		}

		public void save()
		{
			_appDbContext.SaveChanges();
		}

		public void Update(Product product)
		{
			_appDbContext.Update(product);
		}
	}
}
