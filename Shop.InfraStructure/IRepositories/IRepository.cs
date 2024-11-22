using Shop.Model.Models;

namespace Shop.InfraStructure.IRepositories
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : BaseEntity<TKey>, new()
        where TKey : struct
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(TKey id);
        TKey Add(TEntity entity);
        TKey Update(TEntity entity);
        TKey Delete(TEntity entity);
    }
}
