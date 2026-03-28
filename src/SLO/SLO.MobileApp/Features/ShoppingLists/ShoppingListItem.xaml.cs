using Microsoft.Maui.Controls;
using System;
using System.Runtime.CompilerServices;

namespace SLO.MobileApp.Features.ShoppingLists;

public partial class ShoppingListItem : ContentView
{
    public string Name
    {
        get => GetValue();
        set => SetValue(value);
    }

    public decimal Quantity
    {
        get => GetValue();
        set => SetValue(value);
    }

    public string Description
    {
        get => GetValue();
        set => SetValue(value);
    }

    public static readonly BindableProperty NameProperty =
        CreateProperty<string>(propertyName: nameof(Name));

    public static readonly BindableProperty QuantityProperty =
        CreateProperty<decimal>(propertyName: nameof(Quantity));

    public static readonly BindableProperty DescriptionProperty =
        CreateProperty<string>(propertyName: nameof(Description));

    public ShoppingListItem()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private dynamic GetValue(
        [CallerMemberName] string propertyName = null) =>
        propertyName switch
        {
            nameof(Name) => GetValue(NameProperty),
            nameof(Quantity) => GetValue(QuantityProperty),
            nameof(Description) => GetValue(DescriptionProperty),

            _ => throw new ArgumentNullException(nameof(propertyName))
        };

    private void SetValue(
        object value,
        [CallerMemberName] string propertyName = null)
    {
        switch (propertyName)
        {
            case nameof(Name):
                SetValue(NameProperty, value);
                return;

            case nameof(Quantity):
                SetValue(QuantityProperty, value);
                return;

            case nameof(Description):
                SetValue(DescriptionProperty, value);
                return;

            default:
                throw new ArgumentNullException(nameof(propertyName));
        }
    }
    private static BindableProperty CreateProperty<T>(
        string propertyName,
        string defaultValue = null) =>
        BindableProperty.Create(
            propertyName,
            returnType: typeof(T),
            declaringType: typeof(ShoppingListItem),
            defaultValue,
            defaultBindingMode: BindingMode.OneWay);
}