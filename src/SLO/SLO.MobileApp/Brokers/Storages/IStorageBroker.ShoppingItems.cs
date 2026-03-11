using SLO.MobileApp.Models.Foundations.ShoppingItems;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SLO.MobileApp.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<ShoppingItem> InsertShoppingItemAsync(
        ShoppingItem shoppingItem, CancellationToken cancellationToken);

    ValueTask<ShoppingItem> SelectShoppingItemByIdAsync(
        Guid shoppingItemId, CancellationToken cancellationToken);

    ValueTask<ShoppingItem> UpdateShoppingItemAsync(
        ShoppingItem shoppingItem, CancellationToken cancellationToken);
}
