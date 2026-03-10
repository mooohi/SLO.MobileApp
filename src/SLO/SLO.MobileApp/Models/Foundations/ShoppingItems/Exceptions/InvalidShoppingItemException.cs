using Xeptions;

namespace SLO.MobileApp.Models.Foundations.ShoppingItems.Exceptions;

internal class InvalidShoppingItemException : Xeption
{
    public InvalidShoppingItemException(
        string exceptionMessage)
        : base(exceptionMessage) { }
}
