using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SLO.MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

#nullable enable
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}