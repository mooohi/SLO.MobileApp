using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SLO.MobileApp.Views.Controls;

public partial class NumericEntry : ContentView
{
    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public int MinValue
    {
        get => (int)GetValue(MinValueProperty);
        set => SetValue(MinValueProperty, value);
    }

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public NumericEntry()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty ValueProperty =
        CreateProperty<int>(
            propertyName: nameof(Value),
            propertyChangedDelegate: ValueChangedEvent);

    public static readonly BindableProperty MinValueProperty =
        CreateProperty<int>(
            propertyName: nameof(MinValue),
            propertyChangedDelegate: MinValueChangedEvent);

    public static readonly BindableProperty PlaceholderProperty =
        CreateProperty<string>(
            propertyName: nameof(Placeholder));

    public static readonly BindableProperty TextColorProperty =
        CreateProperty<Color>(
            propertyName: nameof(TextColor));

    private static void ValueChangedEvent(BindableObject bindable,
        object oldValue, object newValue)
    {
        var numericEntry = bindable as NumericEntry;

        if (numericEntry is null)
        {
            return;
        }

        if (oldValue.Equals(newValue))
        {
            return;
        }

        if (NotNumeric(value: newValue))
        {
            numericEntry.Value = (int)oldValue;
        }

        if (numericEntry.MinValue <= (int)newValue)
        {
            return;
        }

        numericEntry.Value = numericEntry.MinValue;
    }

    private static void MinValueChangedEvent(BindableObject bindable,
        object oldValue, object newValue)
    {
        var numericEntry = bindable as NumericEntry;

        if (numericEntry is null)
        {
            return;
        }

        if (oldValue.Equals(newValue))
        {
            return;
        }

        if (numericEntry.Value > (int)newValue)
        {
            return;
        }

        numericEntry.Value = (int)newValue;
    }

    private static bool NotNumeric(object value)
    {
        int? intValue = value as int?;

        if (intValue is null)
        {
            return true;
        }

        return false;
    }

    protected static BindableProperty CreateProperty<T>(
        string propertyName,
        object defaultValue = null,
        BindingMode defaultBindingMode = BindingMode.OneWay,
        BindableProperty.BindingPropertyChangedDelegate propertyChangedDelegate = null) =>
        BindableProperty.Create(
            propertyName,
            returnType: typeof(T),
            declaringType: typeof(NumericEntry),
            defaultValue,
            defaultBindingMode,
            propertyChanged: propertyChangedDelegate);
}