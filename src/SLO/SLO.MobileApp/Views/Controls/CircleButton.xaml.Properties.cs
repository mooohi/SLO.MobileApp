using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace SLO.MobileApp.Views.Controls;

public partial class CircleButton
{
    private static readonly BindablePropertyKey BackgroundPropertyKey =
        CreateReadOnlyProperty<Brush>(propertyName: nameof(Background));

    private static readonly BindablePropertyKey BackgroundColorPropertyKey =
        CreateReadOnlyProperty<Color>(propertyName: nameof(BackgroundColor));

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

    public new Brush Background
    { get => (Brush)GetValue(BackgroundPropertyKey.BindableProperty); }

    public new Color BackgroundColor
    { get => (Color)GetValue(BackgroundColorPropertyKey.BindableProperty); }

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

    private static void OnButtonSizeChangedEvent(
        BindableObject bindable,
        object oldValue,
        object newValue)
    {
        if (bindable is not CircleButton circleButton)
        {
            return;
        }

        if (oldValue.Equals(newValue))
        {
            return;
        }

        double widthHeightValue = (double)newValue * 2;
        circleButton.SetValue(BaseButtonDimensionsProperty, widthHeightValue);
    }

    private static BindableProperty CreateProperty<T>(
        string propertyName,
        object defaultValue = null,
        BindingMode defaultBindingMode = BindingMode.OneWay,
        BindableProperty.BindingPropertyChangedDelegate propertyChangedDelegate = null,
        BindableProperty.BindingPropertyChangingDelegate propertyChangingDelegate = null) =>
        BindableProperty.Create(
            propertyName,
            returnType: typeof(T),
            declaringType: typeof(CircleButton),
            defaultValue,
            defaultBindingMode,
            propertyChanged: propertyChangedDelegate,
            propertyChanging: propertyChangingDelegate);

    private static BindablePropertyKey CreateReadOnlyProperty<T>(
        string propertyName,
        object defaultValue = null) =>
        BindableProperty.CreateReadOnly(
            propertyName,
            returnType: typeof(T),
            declaringType: typeof(CircleButton),
            defaultValue);
}
