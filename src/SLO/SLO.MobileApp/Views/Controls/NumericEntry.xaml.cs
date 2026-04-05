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
            propertyChangedDelegate: ValueChangedEvent,
            createDefaultValueDelegate: BindMinValue);

    private static object BindMinValue(BindableObject bindable)
    {
        var numericEntryBase = bindable as NumericEntry;

        if (numericEntryBase is null)
        {
            return default;
        }

        return numericEntryBase.MinValue;
    }

    private static void ValueChangedEvent(BindableObject bindable,
        object oldValue, object newValue)
    {
        var numericEntryBase = bindable as NumericEntry;

        if (numericEntryBase is null)
        {
            return;
        }

        if (numericEntryBase.MinValue <= (int)newValue)
        {
            return;
        }

        numericEntryBase.Value = numericEntryBase.MinValue;
    }

    public static readonly BindableProperty MinValueProperty =
        CreateProperty<int>(propertyName: nameof(MinValue));

    private static BindableProperty CreateProperty<T>(
        string propertyName,
        T defaultValue = default,
        BindingMode defaultBindingMode = BindingMode.OneWay,
        BindableProperty.ValidateValueDelegate validateValueDelegate = null,
        BindableProperty.BindingPropertyChangedDelegate propertyChangedDelegate = null,
        BindableProperty.CreateDefaultValueDelegate createDefaultValueDelegate = null) =>
        BindableProperty.Create(
            propertyName,
            returnType: typeof(T),
            declaringType: typeof(NumericEntry),
            defaultValue,
            defaultBindingMode,
            validateValue: validateValueDelegate,
            propertyChanged: propertyChangedDelegate,
            defaultValueCreator: createDefaultValueDelegate);

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
}