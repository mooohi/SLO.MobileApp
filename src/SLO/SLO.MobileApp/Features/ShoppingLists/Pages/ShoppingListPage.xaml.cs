using Microsoft.Maui.Controls;
using SLO.MobileApp.Core.Models.Foundations.ShoppingItems;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SLO.MobileApp.Features.ShoppingLists.Pages;

public partial class ShoppingListPage : ContentPage
{
    public ObservableCollection<ShoppingItem> ShoppingItems { get; } =
        new ObservableCollection<ShoppingItem>();

    public ShoppingItem SelectedShoppingItem { get; set; }

    public ShoppingListPage()
    {
        InitializeComponent();
        this.BindingContext = this;
    }

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

            case EditShoppingListItemPage page:
                UpdateModifiedShoppingItem(page);
                return;

            default:
                return;
        }
    }

    private async void AddNewItemClicked(
        object sender,
        EventArgs e) =>
        await AppShell.Current.Navigation.PushModalAsync(
            page: new AddShoppingListItemPage(),
            animated: true);

    private void CaptureAddedShoppingItem(
        AddShoppingListItemPage page)
    {
        if (page.Discarded)
        {
            return;
        }

        var capturedShoppingItem =
                new ShoppingItem
                {
                    Name = page.Name,
                    Description = page.Description,
                    Quantity = page.Quantity,
                };

        ShoppingItems.Add(capturedShoppingItem);

        ItemsCollectionView.ScrollTo(
            item: capturedShoppingItem,
            position: ScrollToPosition.MakeVisible,
            animate: true);
    }

    private void UpdateModifiedShoppingItem(
        EditShoppingListItemPage page)
    {
        if (SelectedShoppingItem is null)
        {
            return;
        }

        if (page.Discarded)
        {
            return;
        }

        ShoppingItem foundShoppingItem =
            ShoppingItems.FirstOrDefault(shoppingItem =>
            shoppingItem.Equals(SelectedShoppingItem));

        if (foundShoppingItem is null)
        {
            return;
        }

        ShoppingItem updatedShoppingItem =
            new ShoppingItem
            {
                Name = page.Name,
                Description = page.Description,
                Quantity = page.Quantity,
            };

        int currentItemIndex = ShoppingItems.IndexOf(foundShoppingItem);
        ShoppingItems[currentItemIndex] = updatedShoppingItem;
    }

    private void RemoveShoppingItemClicked(
        object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;

        if (swipeItem is null)
        {
            return;
        }

        ShoppingItem shoppingItem =
            swipeItem.BindingContext as ShoppingItem;

        if (shoppingItem is null)
        {
            return;
        }

        ShoppingItems.Remove(item: shoppingItem);
    }

    private async void EditShoppingItemClicked(
        object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;

        if (swipeItem is null)
        {
            return;
        }

        ShoppingItem shoppingItem =
            swipeItem.BindingContext as ShoppingItem;

        if (shoppingItem is null)
        {
            return;
        }

        SelectedShoppingItem = shoppingItem;

        var editShoppingListItemPage =
            new EditShoppingListItemPage(
                name: shoppingItem.Name,
                description: shoppingItem.Description,
                quantity: shoppingItem.Quantity);

        await AppShell.Current.Navigation.PushModalAsync(
            page: editShoppingListItemPage,
            animated: true);
    }
}