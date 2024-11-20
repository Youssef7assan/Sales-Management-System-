using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public interface ISuppliersRepository
	{
		public List<Supplier> GetAll();
		public Supplier GetById(int id);
		public void Delete(int id);
		public void Update(Supplier supplier);
		public void Add(Supplier supplier);
		public void save();
	}
}
