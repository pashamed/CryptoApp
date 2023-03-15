using System;

using CryproApp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CryproApp.Views
{
    public sealed partial class ConvertPage : Page
    {
        public ConvertViewModel ViewModel { get; } = new ConvertViewModel();

        public ConvertPage()
        {
            InitializeComponent();
        }
    }
}
