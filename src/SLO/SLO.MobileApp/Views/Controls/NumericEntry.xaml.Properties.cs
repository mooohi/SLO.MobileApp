using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SLO.MobileApp.Views.Controls;

public partial class NumericEntry
{
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
