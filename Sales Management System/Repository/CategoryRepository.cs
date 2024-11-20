using Microsoft.EntityFrameworkCore;
using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public class CategoryRepository : ICategoryRepository
	{
		AppDbContext _appDbContext;
		public CategoryRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public void Add(Category category)
		{
			_appDbContext.Categories.Add(category);
		}

		public List<Category> GetAll()
		{
			List<Category> result = _appDbContext.Categories.ToList();
			return result;
		}

		public Category GetById(int id)
		{
			Category category = _appDbContext.Categories.FirstOrDefault(p => p.Id == id);
			return category;
		}

		public void Delete(int id)
		{
			Category category = GetById(id);
			_appDbContext.Categories.Remove(category);

		}
		public void save()
		{
			_appDbContext.SaveChanges();
		}

		public void Update(Category category)
		{
			_appDbContext.Update(category);
		}
	}
}
