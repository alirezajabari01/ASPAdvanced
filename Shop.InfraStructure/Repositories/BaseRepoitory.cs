using Shop.InfraStructure.Contexts;
using Shop.InfraStructure.IRepositories;
using Shop.Model.Models;

namespace Shop.InfraStructure.Repositories
{
    public class BaseRepoitory<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>, new()
        where TKey : struct
    {
        private readonly ShopContext context;
        public BaseRepoitory(ShopContext context)
        {
            this.context = context;
        }

        public TKey Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
            return entity.Id;
        }

        public TKey Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public TEntity GetById(TKey id)
        {
            return context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
        }

        public TKey Update(TEntity entity)
        {
            throw new NotImplementedException();
        }


    }
}
