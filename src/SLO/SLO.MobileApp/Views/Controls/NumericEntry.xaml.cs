using Microsoft.Maui.Controls;
using System;
using System.Runtime.CompilerServices;

namespace SLO.MobileApp.Views.Controls;

public partial class NumericEntry : ContentView
{
    public int Value
    {
        get => GetValue();
        set => SetValue(value);
    }

    public int MinValue
    {
        get => GetValue();
        set => SetValue(value);
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

    private dynamic GetValue(
        [CallerMemberName] string propertyName = null) =>
        propertyName switch
        {
            nameof(Value) => GetValue(ValueProperty),
            nameof(MinValue) => GetValue(MinValueProperty),

            _ => throw new ArgumentNullException(nameof(propertyName))
        };

    private void SetValue(
        object value,
        [CallerMemberName] string propertyName = null)
    {
        switch (propertyName)
        {
            case nameof(Value):
                SetValue(ValueProperty, value);
                return;

            case nameof(MinValue):
                SetValue(MinValueProperty, value);
                return;

            default:
                throw new ArgumentNullException(nameof(propertyName));
        }
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