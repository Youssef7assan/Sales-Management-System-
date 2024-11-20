using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public interface ICustomerRepository
	{

		public List<Customer> GetAll();
		public Customer GetById(int id);
		public void Delete(int id);
		public void Update(Customer customers);
		public void Add(Customer customers);
		public void save();
	}
}
