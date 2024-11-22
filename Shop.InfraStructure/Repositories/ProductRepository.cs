using Shop.InfraStructure.Contexts;
using Shop.InfraStructure.IRepositories;
using Shop.Model.Models;

namespace Shop.InfraStructure.Repositories
{
    public class ProductRepository : BaseRepoitory<Product, int>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {

        }
    }
}
