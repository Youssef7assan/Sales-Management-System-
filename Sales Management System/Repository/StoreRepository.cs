using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public class StoreRepository:IStoreRepository
	{
		private readonly AppDbContext _appDbContext;

		public StoreRepository(AppDbContext appDbContext)
		{
			this._appDbContext = appDbContext;
		}
		public void Add(Store store)
		{
			_appDbContext.Stores.Add(store);
		}

		public List<Store> GetAll()
		{
			List<Store> result = _appDbContext.Stores.ToList();
			return result;
		}

		public Store GetById(int id)
		{
			Store store = _appDbContext.Stores.FirstOrDefault(p => p.Id == id);
			return store;
		}

		public void Delete(int id)
		{
			Store store = GetById(id);
			_appDbContext.Stores.Remove(store);

		}
		public void save()
		{
			_appDbContext.SaveChanges();
		}

		public void Update(Store store)
		{
			_appDbContext.Update(store);
		}

	}
}
