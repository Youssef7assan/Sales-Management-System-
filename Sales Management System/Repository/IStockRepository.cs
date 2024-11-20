using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public interface IStockRepository
	{
		public List<Stock> GetAll();
		public Stock GetById(int id);
		public void Delete(int id);
		public void Update(Stock stock);
		public void Add(Stock stock);
		public void save();
	}
}
