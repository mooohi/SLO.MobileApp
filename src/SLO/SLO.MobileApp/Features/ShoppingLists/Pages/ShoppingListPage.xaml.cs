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
        BuildShoppingItems();
    }

    private void BuildShoppingItems()
    {
        for (int i = 1; i <= 59; i++)
        {
            ShoppingItems.Add(
                new ShoppingItem
                {
                    Name = GetRandomString(),
                    Description = Guid.NewGuid().ToString(),
                    Quantity = i,
                });
        }
    }

    private string GetRandomString(int length = 10)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var buffer = new char[length];

        for (int i = 0; i < length; i++)
        {
            buffer[i] = chars[random.Next(length)];
        }

        return new string(buffer);
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
        if (args?.PreviousPage is AddShoppingListItemPage addShoppingListItemPage)
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
    }
}