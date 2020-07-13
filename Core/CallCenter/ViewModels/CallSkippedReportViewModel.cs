using System;
using System.ComponentModel;
using System.Globalization;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class CallSkippedReportViewModel : ViewModelBase
    {
        public CallSkippedReportViewModel(DateTime callSkipDateTime)
        {
            DateOfSkip = callSkipDateTime.Date.ToString("MM/dd/yyyy");
            //TimeOfSkip = String.Format("{0:hh:mm tt}", callSkipDateTime);
            TimeOfSkip = callSkipDateTime.ToString("hh:mm tt", CultureInfo.InvariantCulture);
        }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Call Queue")]
        public string CallQueue { get; set; }

        [DisplayName("Health Plan")]
        public string HealthPlan { get; set; }

        [DisplayName("Call Skip Date")]
        public string DateOfSkip { get; private set; }

        [DisplayName("Call Skip Time")]
        public string TimeOfSkip { get; private set; }

        [DisplayName("Agent Name")]
        public string AgentName { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }

        [Hidden]
        public DateTime CallSkipDateTime { get; set; }
    }
}
