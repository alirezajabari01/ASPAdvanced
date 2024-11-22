using Microsoft.EntityFrameworkCore.Diagnostics;
using Shop.InfraStructure.Contexts;
using Shop.Model.Models;

namespace Shop.InfraStructure.Interceptors
{
    public class ProductHistoryInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null)
                return base.SavingChanges(eventData, result);

            var shopContex = eventData.Context as ShopContext;

            var changedProduct = shopContex.ChangeTracker.Entries<Product>().FirstOrDefault();
            if (changedProduct == default)
                return base.SavingChanges(eventData, result);

            var history = new ProductHistory
            {
                Name = changedProduct.Entity.Name,
                Quantity = changedProduct.Entity.Quantity,
                Price = changedProduct.Entity.Price,
            };

            shopContex.ProductHistory.Add(history);
            return base.SavingChanges(eventData, result);
        }
    }
}
