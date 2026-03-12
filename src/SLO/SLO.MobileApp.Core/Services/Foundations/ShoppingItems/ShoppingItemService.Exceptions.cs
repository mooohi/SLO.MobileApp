using Microsoft.Data.SqlClient;
using SLO.MobileApp.Core.Models.Foundations.ShoppingItems;
using SLO.MobileApp.Core.Models.Foundations.ShoppingItems.Exceptions;
using System;
using System.Threading.Tasks;

namespace SLO.MobileApp.Core.Services.Foundations.ShoppingItems;

internal sealed partial class ShoppingItemService
{
    private delegate ValueTask<ShoppingItem> ReturningShoppingItemFunctions();

    private async ValueTask<ShoppingItem> TryCatch(
        ReturningShoppingItemFunctions returningShoppingItemFunctions)
    {
        try
        {
            return await returningShoppingItemFunctions();
        }
        catch (NullShoppingItemException ex)
        {
            throw await CreateValidationErrorAsync(ex);
        }
        catch (InvalidShoppingItemException ex)
        {
            throw await CreateValidationErrorAsync(ex);
        }
        catch (SqlException ex)
        {
            var failedShoppingItemStorageException =
                new FailedShoppingItemStorageException(
                    exceptionMessage: "Failed shopping item storage error occurred, " +
                    "please contact support.",
                    innerException: ex);

            throw await CreateCriticalDependencyErrorAsync(
                failedShoppingItemStorageException);
        }
    }

    private async ValueTask<ShoppingItemValidationException> CreateValidationErrorAsync(
        Exception exception)
    {
        var shoppingItemValidationException =
            new ShoppingItemValidationException(
                exceptionMessage: "Shopping item validation error occurred, " +
                "fix the errors and try again please!",
                innerException: exception);

        await _loggingBroker.LogErrorAsync(
            shoppingItemValidationException);

        return shoppingItemValidationException;
    }

    private async ValueTask<ShoppingItemDependencyException> CreateCriticalDependencyErrorAsync(
        Exception exception)
    {
        var shoppingItemDependencyException =
            new ShoppingItemDependencyException(
                exceptionMessage: "Shopping item dependency error occurred, " +
                "please contact support.",
                innerException: exception);

        await _loggingBroker.LogCriticalAsync(
            shoppingItemDependencyException);

        return shoppingItemDependencyException;
    }
}
