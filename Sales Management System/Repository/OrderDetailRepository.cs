using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public class OrderDetailRepository
	{
		private readonly AppDbContext _appDbContext;

		public OrderDetailRepository(AppDbContext appDbContext)
		{
			this._appDbContext = appDbContext;
		}
		public void Add(OrderDetail order)
		{
			_appDbContext.OrderDetails.Add(order);
		}

		public List<OrderDetail> GetAll()
		{
			List<OrderDetail> result = _appDbContext.OrderDetails.ToList();
			return result;
		}

		public OrderDetail GetById(int id)
		{
			OrderDetail order = _appDbContext.OrderDetails.FirstOrDefault(p => p.ID == id);
			return order;
		}

		public void Delete(int id)
		{
			OrderDetail order = GetById(id);
			_appDbContext.OrderDetails.Remove(order);

		}
		public void save()
		{
			_appDbContext.SaveChanges();
		}

		public void Update(OrderDetail order)
		{
			_appDbContext.Update(order);
		}
	}
}
