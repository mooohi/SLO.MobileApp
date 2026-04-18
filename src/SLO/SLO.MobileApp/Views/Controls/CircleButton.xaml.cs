using Microsoft.Maui.Controls;
using System;

namespace SLO.MobileApp.Views.Controls;

public partial class CircleButton : TemplatedView
{
    public CircleButton()
    {
        InitializeComponent();
    }

    private void ButtonClicked(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}