using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public interface ICategoryRepository
	{
		public List<Category> GetAll();
		public Category GetById(int id);
		public void Delete(int id);
		public void Update(Category category);
		public void Add(Category category);
		public void save();
		
	}
}
