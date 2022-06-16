namespace FashionShop.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}