using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public interface ICreditRepository
	{
		public List<Credit> GetAll();
		public Credit GetById(int id);
		public void Delete(int id);
		public void Update(Credit credit);
		public void Add(Credit credit);
		public void save();
	}
}
