using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace SLO.MobileApp.Views.Controls;

public partial class CircleButton
{
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public FontAttributes FontAttributes
    {
        get => (FontAttributes)GetValue(FontAttributesProperty);
        set => SetValue(FontAttributesProperty, value);
    }

    public int FontSize
    {
        get => (int)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public double Size
    {
        get => (double)GetValue(SizeProperty);
        set => SetValue(SizeProperty, value);
    }

    public Color ButtonColor
    {
        get => (Color)GetValue(ButtonColorProperty);
        set => SetValue(ButtonColorProperty, value);
    }

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public double BaseButtonDimensions
    {
        get => (double)GetValue(BaseButtonDimensionsProperty);
        private set => SetValue(BaseButtonDimensionsProperty, value);
    }

    public event EventHandler Clicked;

    public static readonly BindableProperty TextProperty =
        CreateProperty<string>(propertyName: nameof(Text));

    public static readonly BindableProperty FontAttributesProperty =
        CreateProperty<FontAttributes>(propertyName: nameof(FontAttributes));

    public static readonly BindableProperty FontSizeProperty =
        CreateProperty<int>(propertyName: nameof(FontSize));

    public static readonly BindableProperty SizeProperty =
        CreateProperty<double>(
            propertyName: nameof(Size),
            propertyChangedDelegate: OnButtonSizeChangedEvent);

    public static readonly BindableProperty ButtonColorProperty =
        CreateProperty<Color>(propertyName: nameof(ButtonColor));

    public static readonly BindableProperty TextColorProperty =
        CreateProperty<Color>(propertyName: nameof(TextColor));

    public static readonly BindableProperty BaseButtonDimensionsProperty =
        CreateProperty<double>(
            propertyName: nameof(BaseButtonDimensions));

    private static BindableProperty CreateProperty<T>(
        string propertyName,
        object defaultValue = null,
        BindingMode defaultBindingMode = BindingMode.OneWay,
        BindableProperty.BindingPropertyChangedDelegate propertyChangedDelegate = null) =>
        BindableProperty.Create(
            propertyName,
            returnType: typeof(T),
            declaringType: typeof(CircleButton),
            defaultValue,
            defaultBindingMode,
            propertyChanged: propertyChangedDelegate);

    private static BindablePropertyKey CreateReadOnlyProperty<T>(
        string propertyName,
        object defaultValue = null) =>
        BindableProperty.CreateReadOnly(
            propertyName,
            returnType: typeof(T),
            declaringType: typeof(CircleButton),
            defaultValue);
}
