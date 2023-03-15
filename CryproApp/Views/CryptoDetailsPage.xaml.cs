using System;

using CryproApp.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CryproApp.Views
{
    public sealed partial class CryptoDetailsPage : Page
    {
        public CryptoDetailsViewModel ViewModel { get; } = new CryptoDetailsViewModel();

        public CryptoDetailsPage()
        {
            
            InitializeComponent();
            Loaded += CryptoDetailsPage_Loaded;
        }

        private async void CryptoDetailsPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(ListDetailsViewControl.ViewState);
        }
    }
}
