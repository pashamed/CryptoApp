using System;
using System.Linq;
using System.Threading.Tasks;
using CryproApp.Core.Services;
using CryproApp.ViewModels;
using Microsoft.Toolkit.Uwp.UI;
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
