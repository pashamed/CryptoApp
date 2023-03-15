using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static CryproApp.Core.Models.CandleDataPoint;

namespace CryproApp.Core.Models
{
    public class CandleDataPoint
    {
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string close { get; set; }
        public string volume { get; set; }
        public object period { get; set; }
    }
    public class CandleData
    {
        public List<CandleDataPoint> data { get; set; }
        public long timestamp { get; set; }
    }
}
