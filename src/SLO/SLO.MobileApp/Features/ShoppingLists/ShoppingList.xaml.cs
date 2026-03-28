using Microsoft.Maui.Controls;
using SLO.MobileApp.Core.Models.Foundations.ShoppingItems;
using System;
using System.Collections.Generic;

namespace SLO.MobileApp.Features.ShoppingLists;

public partial class ShoppingList : ContentView
{
    public List<ShoppingItem> ShoppingItems { get; } = [];

    public ShoppingList()
    {
        InitializeComponent();
        this.BindingContext = this;
        BuildShoppingItems();
    }

    private void BuildShoppingItems()
    {
        for (int i = 1; i <= 20; i++)
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

}