using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly AppDbContext _appDbContext;

		public CustomerRepository(AppDbContext appDbContext)
		{
			this._appDbContext = appDbContext;
		}

		public void Add(Customer customer)
		{
			_appDbContext.customers.Add(customer);
		}

		public List<Customer> GetAll()
		{
			List<Customer> result = _appDbContext.customers.ToList();
			return result;
		}

		public Customer GetById(int id)
		{
			Customer customer = _appDbContext.customers.FirstOrDefault(p => p.Id == id);
			return customer;
		}

		public void Delete(int id)
		{
			Customer customer = GetById(id);
			_appDbContext.customers.Remove(customer);

		}
		public void save()
		{
			_appDbContext.SaveChanges();
		}

		public void Update(Customer customer)
		{
			_appDbContext.Update(customer);
		}
	}
}
