using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public class CreditRepository : ICreditRepository
	{
		private readonly AppDbContext _appDbContext;

		public CreditRepository(AppDbContext appDbContext)
		{
			this._appDbContext = appDbContext;
		}

		public void Add(Credit credit)
		{
			_appDbContext.credits.Add(credit);
		}

		public List<Credit> GetAll()
		{
			List<Credit> result = _appDbContext.credits.ToList();
			return result;
		}

		public Credit GetById(int id)
		{
			Credit credit = _appDbContext.credits.FirstOrDefault(p => p.Id == id);
			return credit;
		}

		public void Delete(int id)
		{
			Credit credit = GetById(id);
			_appDbContext.credits.Remove(credit);

		}
		public void save()
		{
			_appDbContext.SaveChanges();
		}

		public void Update(Credit credit)
		{
			_appDbContext.Update(credit);
		}
	}
}

