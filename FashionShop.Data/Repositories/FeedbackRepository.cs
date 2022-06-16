using FashionShop.Data.Infrastructure;
using FashionShop.Model.Models;

namespace FashionShop.Data.Repositories
{
    public interface IFeedbackRepository : IRepository<FeedBack>
    {

    }
    public class FeedbackRepository : RepositoryBase<FeedBack>, IFeedbackRepository
    {
        public FeedbackRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
