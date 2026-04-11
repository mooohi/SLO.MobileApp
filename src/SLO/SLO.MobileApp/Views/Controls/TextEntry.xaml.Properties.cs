using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SLO.MobileApp.Views.Controls;

public partial class TextEntry
{
    public static readonly BindableProperty FontAttributesProperty =
        CreateProperty<FontAttributes>(propertyName: nameof(FontAttributes));

    public static readonly BindableProperty FontSizeProperty =
        CreateProperty<int>(propertyName: nameof(FontSize));

    public static readonly BindableProperty PlaceholderProperty =
        CreateProperty<string>(propertyName: nameof(Placeholder));

    public static readonly BindableProperty TextProperty =
        CreateProperty<string>(propertyName: nameof(Text));

    public static readonly BindableProperty ColorProperty =
        CreateProperty<Color>(propertyName: nameof(TextColor));

    protected static BindableProperty CreateProperty<T>(
        string propertyName,
        object defaultValue = null,
        BindingMode defaultBindingMode = BindingMode.OneWay) =>
        BindableProperty.Create(
            propertyName,
            returnType: typeof(T),
            declaringType: typeof(TextEntry),
            defaultValue,
            defaultBindingMode);
}
