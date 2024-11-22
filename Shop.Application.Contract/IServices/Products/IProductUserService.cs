using Shop.Application.Contract.Dtos.Products;
using Shop.Application.Contract.Dtos.Quantities;

namespace Shop.Application.Contract.IServices.Products
{
    public interface IProductUserService
    {
        int GetQuantity(QuantityRequestDto dto);
        List<ProductDto> Get();
        PagingModel<List<ProductDto>> GetWithFilter(ProductFilterDto dto);
        ProductDto GetById(int id);
    }
}
