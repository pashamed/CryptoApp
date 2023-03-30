using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CryproApp.Core.Models;
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


        // Autosuggest search box events
        private async void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                string text = sender.Text;
                sender.ItemsSource = await Task.Run(() => GetCurrency(text));
            }
        }
      
        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

            sender.Text = GetCurrency(sender.Text).FirstOrDefault().Id;
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                ViewModel.Selected = GetCurrency(sender.Text).FirstOrDefault();
            }
            else { }
        }
        private IEnumerable<Currency> GetCurrency(string v)
        {
            return ViewModel.SampleItems.Where(x => x.Id.Contains(v)).ToList();
        }
    }
}
