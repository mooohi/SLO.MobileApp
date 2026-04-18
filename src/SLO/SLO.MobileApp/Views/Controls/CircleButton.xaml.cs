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

            case nameof(BackgroundColor) when (BackgroundColor != ButtonColor):
                SetValue(VisualElement.BackgroundColorProperty, ButtonColor);
                break;

            default:
                return;
        }
    }

    private void ButtonClicked(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}