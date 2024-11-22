using Shop.Model.Models;

namespace Shop.InfraStructure.IRepositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
        //IQueryable<Product> GetAll();
        //IQueryable<Product> GetById(int id);
        //Product FindById(int id);
        //int Add(Product product);
        //int Update(Product product);
        ////int Delete(Product product);
        //IQueryable<Product> Search(string keyword);
    }
}
