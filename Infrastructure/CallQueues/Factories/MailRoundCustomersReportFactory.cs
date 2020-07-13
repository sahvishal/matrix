using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.CallQueues.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Factories
{
    [DefaultImplementation]
    public class MailRoundCustomersReportFactory : IMailRoundCustomersReportFactory
    {
        public MailRoundCustomersListModel Create(IEnumerable<Customer> customers, IEnumerable<Core.CallCenter.Domain.Call> calls, IEnumerable<DirectMail> directMails, IEnumerable<CorporateCustomerCustomTag> customTags)
        {
            var collection = new List<MailRoundCustomersReportViewModel>();

            foreach (var customer in customers)
            {
                var model = new MailRoundCustomersReportViewModel();
                var customerCalls = calls != null ? calls.Where(c => c.CalledCustomerId == customer.CustomerId) : null;
                var callDetail = customerCalls != null ? customerCalls.OrderByDescending(x => x.CallDateTime).FirstOrDefault() : null;
                var customerDirectMails = directMails != null ? directMails.Where(x => x.CustomerId == customer.CustomerId) : null;
                var customerCustomTags = customTags != null ? customTags.Where(x => x.CustomerId == customer.CustomerId).Select(x => x.Tag) : null;

                model.CustomerID = customer.CustomerId;
                model.FirstName = customer.Name.FirstName;
                model.LastName = customer.Name.LastName;
                model.DOB = customer.DateOfBirth;
                model.State = customer.Address.State;
                model.Zip = customer.Address.ZipCode.Zip;
                model.Tag = customer.Tag;
                model.CustomTags = customerCustomTags != null ? string.Join(", ", customerCustomTags) : "N/A";
                model.TotalOutboundCallCount = customerCalls != null ? customerCalls.Count() : 0;
                model.TotalDirectMailCount = customerDirectMails != null ? customerDirectMails.Count() : 0;
                model.LatestCallDate = callDetail != null && callDetail.StartTime.HasValue ? callDetail.StartTime.Value.ToString("MM/dd/yyyy") : "N/A";
                model.LatestCallTime = callDetail != null && callDetail.StartTime.HasValue ? callDetail.StartTime.Value.ToString("hh:mm tt") : "N/A";

                model.Disposition = "N/A";
                if (callDetail != null)
                {
                    ProspectCustomerTag prospectCustomerTag;
                    Enum.TryParse(callDetail.Disposition, out prospectCustomerTag);
                    var isDefined = Enum.IsDefined(typeof(ProspectCustomerTag), prospectCustomerTag);

                    model.Disposition = callDetail.Disposition != string.Empty && isDefined ? prospectCustomerTag.GetDescription() : "N/A";
                }

                model.LatestMailDate = "N/A";

                if (!customerDirectMails.IsNullOrEmpty())
                {
                    model.LatestMailDate = customerDirectMails.OrderByDescending(x => x.MailDate).First().MailDate.ToString("MM/dd/yyyy");
                }

                collection.Add(model);
            }

            return new MailRoundCustomersListModel { Collection = collection };
        }
    }
}
