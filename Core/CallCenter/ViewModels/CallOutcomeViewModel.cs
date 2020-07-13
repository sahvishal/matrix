using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallOutcomeViewModel
    {
        public int OutCometype { get; set; }
        public bool IsCallBackRequested { get; set; }
        public DateTime? CallBackRequested { get; set; }
        public string Notes { get; set; }
    }
}