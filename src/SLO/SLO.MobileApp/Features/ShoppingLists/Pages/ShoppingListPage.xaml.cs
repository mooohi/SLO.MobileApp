using Microsoft.Maui.Controls;
using SLO.MobileApp.Core.Models.Foundations.ShoppingItems;
using System;
using System.Collections.ObjectModel;

namespace SLO.MobileApp.Features.ShoppingLists.Pages;

public partial class ShoppingListPage : ContentPage
{
    public ObservableCollection<ShoppingItem> ShoppingItems { get; } =
        new ObservableCollection<ShoppingItem>();

    public ShoppingListPage()
    {
        InitializeComponent();
        this.BindingContext = this;
    }

    private async void AddNewItemButton(
        object sender,
        EventArgs e) =>
        await AppShell.Current.Navigation.PushModalAsync(
            page: new AddShoppingListItemPage(),
            animated: true);

    protected override void OnNavigatedTo(
        NavigatedToEventArgs args)
    {
        switch (args?.PreviousPage)
        {
            case ShoppingListPage:
                return;

            case AddShoppingListItemPage page:
                CaptureAddedShoppingItem(page);
                return;

            default:
                return;
        }
    }

    private void CaptureAddedShoppingItem(
        AddShoppingListItemPage addShoppingListItemPage)
    {
        var capturedShoppingItem =
                new ShoppingItem
                {
                    Name = addShoppingListItemPage.Name,
                    Description = addShoppingListItemPage.Description,
                    Quantity = addShoppingListItemPage.Quantity,
                };

        ShoppingItems.Add(capturedShoppingItem);

        ItemsCollectionView.ScrollTo(
            item: capturedShoppingItem,
            position: ScrollToPosition.MakeVisible,
            animate: true);
    }

    private void RemoveShoppingItem(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;

        if (swipeItem is null)
        {
            return;
        }

        var shoppingListItem =
            swipeItem.BindingContext as ShoppingItem;

        ShoppingItems.Remove(item: shoppingListItem);
    }
}