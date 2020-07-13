using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class CustomerScheduleCsvHelper : ICustomerScheduleCsvHelper
    {
        public StringBuilder GetPatientScheduledReport(IEnumerable<EventCustomerScheduleModel> modelData, CSVExporter<CustomerScheduleModel> exporter)
        {
            long[] eventIds = modelData.Select(m => m.EventId).Distinct().ToArray();
            var csvStringBuilder = new StringBuilder();

            foreach (var eventId in eventIds)
            {
                csvStringBuilder.Append(
                    "/***********************************************************************************/" +
                    Environment.NewLine);

                var eventData = modelData.Where(m => m.EventId == eventId).FirstOrDefault();
                var customerData = modelData.Where(m => m.EventId == eventId).SelectMany(m => m.Customers);

                csvStringBuilder.Append("EventId:" + eventData.EventId + ", EventDate: " + eventData.EventDate.Date +
                                        ", Location:" + eventData.Location);
                csvStringBuilder.Append(", Address: " + eventData.Address.StreetAddressLine1 + " " +
                                        eventData.Address.StreetAddressLine2 + " " + eventData.Address.City + " " +
                                        eventData.Address.State + " - " + eventData.Address.ZipCode.Zip + ", Pod: " +
                                        eventData.Vehicle + Environment.NewLine);
                csvStringBuilder.Append(exporter.Header + Environment.NewLine);
                foreach (string line in exporter.ExportObjects(customerData))
                {
                    csvStringBuilder.Append(line + Environment.NewLine);
                }
                csvStringBuilder.Append(Environment.NewLine);
                csvStringBuilder.Append(Environment.NewLine);
            }

            return csvStringBuilder;
        }
    }
}