using Shop.Application.Contract.Dtos.Products;

namespace Shop.Application.Contract.IServices.Products
{
    public interface IProductAdminService
    {
        bool Add(ProductAddDto dto); 
    }
}
