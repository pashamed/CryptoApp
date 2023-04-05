using CryproApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using CryproApp.Core.Helpers;

namespace CryproApp.Core.Services
{
    public static class CurrencyDataService
    {
        private static List<Currency> Currencies = new List<Currency>();
        public static async Task<IEnumerable<Currency>> GetListDetailsDataAsync()
        {
            await PreLoadData();
            return Currencies;
        }

        public static Task PreLoadData()
        {
            if (true)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://api.coincap.io/v2/");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "251cb894-b470-443d-a564-8362e3339dd1");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync("assets").Result;
                    response.EnsureSuccessStatusCode();
                    string s = response.Content.ReadAsStringAsync().Result;

                    var deserialized = JsonConvert.DeserializeObject<DataJson>(s);
                    foreach (var item in deserialized.data)
                    {
                        Currencies.Add(item);
                    }
                }
                return Task.CompletedTask; 
            }
        }

        public static async Task<IEnumerable<CandleDataPoint>> GetChartDataAsync()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public static async Task<Currency> GetHistoryDataAsync(Currency item)
        {
            CandleData candleData = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.coincap.io/v2/assets/"+item.Id+"/history?interval=d1");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "251cb894-b470-443d-a564-8362e3339dd1");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("");
                response.EnsureSuccessStatusCode();
                candleData = JsonConvert.DeserializeObject<CandleData>(response.Content.ReadAsStringAsync().Result);
            }
            if(candleData != null)
            {
                item.candleDataPoints = candleData.data.Skip(candleData.data.Count() - 15).ToList();
                item.candleDataPoints.ForEach(i => i.priceUsd = Math.Round(i.priceUsd, 3));
            }           
            return item;
        }
    }
}
