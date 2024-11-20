using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public class SuppliersRepository:ISuppliersRepository
	{
		private readonly AppDbContext _appDbContext;

		public SuppliersRepository(AppDbContext appDbContext)
		{
			this._appDbContext = appDbContext;
		}
		public void Add(Supplier supplier)
		{
			_appDbContext.Suppliers.Add(supplier);
		}

		public List<Supplier> GetAll()
		{
			List<Supplier> result = _appDbContext.Suppliers.ToList();
			return result;
		}

		public Supplier GetById(int id)
		{
			Supplier supplier = _appDbContext.Suppliers.FirstOrDefault(p => p.Id == id);
			return supplier;
		}

		public void Delete(int id)
		{
			Supplier supplier = GetById(id);
			_appDbContext.Suppliers.Remove(supplier);

		}
		public void save()
		{
			_appDbContext.SaveChanges();
		}

		public void Update(Supplier supplier)
		{
			_appDbContext.Update(supplier);
		}

	}
}
