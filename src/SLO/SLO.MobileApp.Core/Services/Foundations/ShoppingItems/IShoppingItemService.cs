using SLO.MobileApp.Core.Models.Foundations.ShoppingItems;
using System.Threading;
using System.Threading.Tasks;

namespace SLO.MobileApp.Core.Services.Foundations.ShoppingItems;

internal interface IShoppingItemService
{
    ValueTask<ShoppingItem> AddShoppingItemAsync(
        ShoppingItem shoppingItem, CancellationToken cancellationToken);

    ValueTask<ShoppingItem> ModifyShoppingItemAsync(
        ShoppingItem shoppingItem, CancellationToken cancellationToken);
}
