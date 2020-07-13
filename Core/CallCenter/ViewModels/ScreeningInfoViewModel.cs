using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class ScreeningInfoViewModel
    {
        public DateTime LastScreeningDate { get; set; }
        public AddressViewModel EventLocation { get; set; }
        public string HostName { get; set; }
        public IEnumerable<OrderedPair<string, string>> ResultSummary { get; set; }
        public string Result { get; set; }
    }
}