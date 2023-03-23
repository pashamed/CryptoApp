using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryproApp.Core.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Currency
    {
        public string Id { get; set; }
        public int Rank { get; set; }
        [JsonProperty("symbol")]
        public string CurrencyCode { get; set; }
        public string Name { get; set; }
        public double Supply { get; set; } = 0.0;
        public double MaxSupply { get; set; } = 0.0;
        public double MarketCapUsd { get; set; } = 0.0;
        [JsonProperty("volumeUsd24Hr")]
        public double VolumeUsed24Hr { get; set; } = 0.0;
        public double PriceUsd { get; set; } = 0.0;
        public double ChangePercent24Hr { get; set; } = 0.0;
        public double Vwap24Hr { get; set; } = 0.0;
        [JsonIgnore]
        public List<CandleDataPoint> candleDataPoints { get; set; }
    }

    public class DataJson
    {
        public IEnumerable<Currency> data { get; set; }
        public long timestamp { get; set; }
    }
}
