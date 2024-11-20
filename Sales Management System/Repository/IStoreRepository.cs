using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public interface IStoreRepository
	{
		public List<Store> GetAll();
		public Store GetById(int id);
		public void Delete(int id);
		public void Update(Store store);
		public void Add(Store store);
		public void save();
	}
}
