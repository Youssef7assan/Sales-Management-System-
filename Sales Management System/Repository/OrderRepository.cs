using Sales_Management_System.Models;

namespace Sales_Management_System.Repository
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _appDbContext;

		public OrderRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public void Add(Order order)
		{
			_appDbContext.Orders.Add(order);
		}

		public List<Order> GetAll()
		{
			List<Order> orders = _appDbContext.Orders
		.Select(o => new Order
		{
			Id = o.Id,
			OrderDate = o.OrderDate ?? DateTime.MinValue, // تعيين قيمة افتراضية إذا كانت NULL
			TotalAmount = o.TotalAmount,
			IsPaid = o.IsPaid,
			CustomerID = o.CustomerID,
			Status = o.Status,

		}).ToList();

			return orders;
		}

		public Order GetById(int id)
		{
			Order order = _appDbContext.Orders.FirstOrDefault(p => p.Id == id);
			return order;
		}

		public void Delete(int id)
		{
			Order order = GetById(id);
			_appDbContext.Orders.Remove(order);

		}
		public void save()
		{
			_appDbContext.SaveChanges();
		}

		public void Update(Order order)
		{
			_appDbContext.Update(order);
		}

	}
}
