using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CryproApp.Core.Models;
using CryproApp.Core.Services;
using Windows.Services.Maps;

namespace CryproApp.ViewModels
{
    public class ChartViewModel : ObservableObject
    {
        public ObservableCollection<CandleDataPoint> Source { get; } = new ObservableCollection<CandleDataPoint>();

        public ChartViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await CurrencyDataService.GetListDetailsDataAsync();
            foreach (var item in data)
            {
                //Source.Add(new CandleDataPoint);
            }
        }
    }
}
