using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CryproApp.Core.Models;
using CryproApp.Core.Services;
using Microsoft.Toolkit.Uwp.UI.Controls;

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

        public ObservableCollection<Currency> SampleItems { get; set; } = new ObservableCollection<Currency>();

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
