using Microsoft.Maui.Controls;
using SLO.MobileApp.Core.Models.Foundations.ShoppingItems;
using System;
using System.Collections.ObjectModel;

namespace SLO.MobileApp.Features.ShoppingLists.Pages;

public partial class ShoppingListPage : ContentView
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

    private async void AddNewItemButton(object sender, EventArgs e)
    {
        ShoppingItems.Add(new ShoppingItem
        {
            Name = "New item",
            Description = "This item is added now",
            Quantity = ShoppingItems[^1].Quantity + 1,
        });

        ItemsCollectionView.ScrollTo(
                index: ShoppingItems.Count - 1,
                position: ScrollToPosition.End,
                animate: true);
    }
}