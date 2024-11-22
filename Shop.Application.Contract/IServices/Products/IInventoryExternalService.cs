using Shop.Application.Contract.Dtos.Quantities;

namespace Shop.Application.Contract.IServices.Products
{
    public interface IInventoryExternalService
    {
        int GetQuantity(QuantityRequestDto dto);
    }
}
