using FashionShop.Data.Infrastructure;
using FashionShop.Model.Models;

namespace FashionShop.Data.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetails>
    {
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetails>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}