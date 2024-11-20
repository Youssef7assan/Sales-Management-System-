using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public interface IProductRepository
	{
		public List<Product> GetAll();
		public Product GetById(int id);
		public void Delete(int id);
		public void Update(Product product );
		public void Add(Product product);
		public void save();
	}
}
