using System;
using System.Collections.Generic;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling.Impl
{
    public class EventCustomerAggregateCSVExporter : ICSVExportable<EventCustomerAggregate>
    {
        public string Header {get; set;}

        public EventCustomerAggregateCSVExporter()
            : this("Event Date,Event,Source,Coupon Code,Called/Incoming Number,Mode,Customer ID,Signup Date,Paid?,Amount,Package,PodName"
                   + Environment.NewLine)
        {}

        public EventCustomerAggregateCSVExporter(string header)
        {
            Header = header;
        }

        public string ExportToCSV(List<EventCustomerAggregate> eventCustomerAggregatesToExport)
        {
            var commaSeparatedValues = new StringBuilder();
            commaSeparatedValues.Append(Header);
            string previousEventName = string.Empty;
            bool checkForNewEvent = false;
            foreach (var eventCustomerAggregate in eventCustomerAggregatesToExport)
            {
                if (checkForNewEvent && eventCustomerAggregate.EventName != previousEventName)
                {
                    commaSeparatedValues.Append(Environment.NewLine);
                }
                previousEventName = eventCustomerAggregate.EventName;
                string commaSeparatedValue = GetSingleLine(eventCustomerAggregate);
                commaSeparatedValues.Append(commaSeparatedValue);
                checkForNewEvent = true;
            }
            return commaSeparatedValues.ToString();
        }

        public string GetSingleLine(EventCustomerAggregate eventCustomerAggregate)
        {
            var commaSeparatedValue = new StringBuilder();
            var paymentAmount = string.Format("{0:c}", eventCustomerAggregate.PaymentAmount);
            commaSeparatedValue.Append(eventCustomerAggregate.EventDate.ToShortDateString() + ",");
            commaSeparatedValue.Append(eventCustomerAggregate.EventName.Replace(',', ' ') + ",");
            commaSeparatedValue.Append(eventCustomerAggregate.MarketingSource.Replace(',', ' ') + ",");
            commaSeparatedValue.Append(eventCustomerAggregate.SourceCode + ",");
            commaSeparatedValue.Append(eventCustomerAggregate.IncomingPhoneNumber + ",");
            commaSeparatedValue.Append(eventCustomerAggregate.SignUpMode + ",");
            commaSeparatedValue.Append(eventCustomerAggregate.CustomerId + ",");
            commaSeparatedValue.Append(eventCustomerAggregate.EventSignupDate.ToShortDateString() + ",");
            commaSeparatedValue.Append(eventCustomerAggregate.IsPaid.ToString().ToUpper() + ",");
            commaSeparatedValue.Append(paymentAmount.Replace(',', ' ') + ",");
            commaSeparatedValue.Append(eventCustomerAggregate.PackageName.Replace(',', ' ') + ",");
            commaSeparatedValue.Append(eventCustomerAggregate.PodName.Replace(',', ' ') + Environment.NewLine);
            return commaSeparatedValue.ToString();
        }
    }
}