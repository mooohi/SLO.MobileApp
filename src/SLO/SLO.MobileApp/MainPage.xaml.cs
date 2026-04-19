using Microsoft.Maui.Controls;
using SLO.MobileApp.Core.Models.Foundations.ShoppingItems;
using System;
using System.ComponentModel;

namespace SLO.MobileApp;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    private ShoppingItem _shoppingItem;

    public ShoppingItem ShoppingItem
    {
        get { return _shoppingItem; }
        set
        {
            _shoppingItem = value;
            OnPropertyChanged();
        }
    }


    int count = 0;

    public MainPage()
    {
        InitializeComponent();

        ShoppingItem =
            new ShoppingItem
            {
                CreatedAt = DateTime.Now,
                CreatedBy = Guid.NewGuid(),
                Description = "Desc",
                Name = "New",
                Quantity = 123
            };

        BindingContext = this;
    }

#nullable enable
}
