using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static CryproApp.Core.Models.CandleDataPoint;

namespace CryproApp.Core.Models
{
    public class CandleDataPoint
    {
        public double priceUsd { get; set; }
        public long time { get; set; }
        public DateTime date { get; set; }
    }
    public class CandleData
    {
        public List<CandleDataPoint> data { get; set; }
        public long timestamp { get; set; }
    }
}
