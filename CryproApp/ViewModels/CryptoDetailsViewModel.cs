using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CryproApp.Core.Models;
using CryproApp.Core.Services;
using CryproApp.Views;
using Microsoft.Toolkit;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.Helpers;
using Microsoft.Toolkit.Uwp.UI;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Newtonsoft.Json.Linq;
using Telerik.UI.Xaml.Controls.Chart;
using Windows.UI.Core;

namespace CryproApp.ViewModels
{
    public class CryptoDetailsViewModel : ObservableObject
    {
        private Currency _selected;

        public Currency Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                if (_selected != null)
                {
                    var item = SampleItems.FirstOrDefault(i => i.Id == value.Id);
                    if (item != null)
                    {
                        item = Task.Run(async () => await CurrencyDataService.GetHistoryDataAsync(SampleItems.FirstOrDefault(i => i.Id == value.Id))).Result;                     
                    }
                }
                SetProperty(ref _selected, value);
            }
        }

        public ObservableCollection<Currency> SampleItems { get; private set; } = new ObservableCollection<Currency>();

        public CryptoDetailsViewModel()
        {
        }

        public async Task LoadDataAsync(ListDetailsViewState viewState)
        {
            SampleItems.Clear();

            var data = await CurrencyDataService.GetListDetailsDataAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }

            if (viewState == ListDetailsViewState.Both)
            {
                Selected = SampleItems.First();
            }
        }
    }
}
