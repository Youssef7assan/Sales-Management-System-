using Microsoft.EntityFrameworkCore;
using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public class StockRepository:IStockRepository
	{
		private readonly AppDbContext _appDbContext;

		public StockRepository(AppDbContext appDbContext)
		{
			this._appDbContext = appDbContext;
		}
		public void Add(Stock stock)
		{
			_appDbContext.Stocks.Add(stock);
		}

		public List<Stock> GetAll()
		{
			List<Stock> result = _appDbContext.Stocks.Include(o=>o.products).Include(p=>p.store).ToList();
			return result;
		}

		public Stock GetById(int id)
		{
			Stock stock = _appDbContext.Stocks.FirstOrDefault(p => p.Id == id);
			return stock;
		}

		public void Delete(int id)
		{
			Stock stock = GetById(id);
			_appDbContext.Stocks.Remove(stock);

		}
		public void save()
		{
			_appDbContext.SaveChanges();
		}

		public void Update(Stock stock)
		{
			_appDbContext.Update(stock);
		}

	}
}
