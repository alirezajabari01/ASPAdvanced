using Microsoft.EntityFrameworkCore.Storage;
using Shop.InfraStructure.Contexts;

namespace Shop.InfraStructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction transaction;
        private readonly ShopContext context;

        public UnitOfWork(ShopContext context)
        {
            this.context = context;
        }

        public void Begin()
        {
            transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }
    }
}
