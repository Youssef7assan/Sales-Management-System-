using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public interface IOrderRepository
	{
		public List<Order> GetAll();
		public Order GetById(int id);
		public void Delete(int id);
		public void Update(Order order);
		public void Add(Order order);
		public void save();
	}
}
