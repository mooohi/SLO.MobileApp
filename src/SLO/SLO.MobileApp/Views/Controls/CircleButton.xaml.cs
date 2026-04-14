using Microsoft.Maui.Controls;
using System;
using System.Runtime.CompilerServices;

namespace SLO.MobileApp.Views.Controls;

public partial class CircleButton : TemplatedView
{
    public CircleButton()
    {
        InitializeComponent();
    }

    protected override void OnPropertyChanged(
        [CallerMemberName] string propertyName = null)
    {
        ResetTemplatedViewDimensions(propertyName);

        base.OnPropertyChanged(propertyName);
    }

    private void ResetTemplatedViewDimensions(string propertyName)
    {
        switch (propertyName)
        {
            case nameof(WidthRequest) when (WidthRequest != BaseButtonDimensions):
                SetValue(WidthRequestProperty, BaseButtonDimensions);
                break;

            case nameof(HeightRequest) when (HeightRequest != BaseButtonDimensions):
                SetValue(HeightRequestProperty, BaseButtonDimensions);
                break;

            default:
                return;
        }
    }

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

    private void ButtonClicked(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}