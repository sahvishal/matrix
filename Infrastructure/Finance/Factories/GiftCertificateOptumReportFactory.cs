using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Finance;

namespace Falcon.App.Infrastructure.Finance.Factories
{
    [DefaultImplementation]
    public class GiftCertificateOptumReportFactory : IGiftCertificateOptumReportFactory
    {
        public ListModelBase<GiftCertificateReportOptumViewModel, GiftCertificateReportFilter> Create(IEnumerable<Customer> customers, IEnumerable<EventCustomer> eventCustomers, EventVolumeListModel eventListModel, IEnumerable<Order> orders,
            IEnumerable<OrderedPair<long, string>> packages, IEnumerable<OrderedPair<long, string>> tests)
        {
            var model = new GiftCertificateReportListOptumModel();
            var customerExportModels = new List<GiftCertificateReportOptumViewModel>();

            foreach (var eventCustomer in eventCustomers)
            {
                var customer = customers.FirstOrDefault(x => x.CustomerId == eventCustomer.CustomerId);

                if (customer != null)
                {
                    var customerExportModel = new GiftCertificateReportOptumViewModel
                    {
                        CustomerId = customer.CustomerId,
                        FirstName = customer.Name.FirstName,
                        MiddleName = customer.Name.MiddleName,
                        LastName = customer.Name.LastName,
                        PhoneHome = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.ToString() : string.Empty,
                        Gender = customer.Gender.ToString(),
                        DateofBirth = customer.DateOfBirth,
                        Address1 = customer.Address.StreetAddressLine1,
                        Address2 = customer.Address.StreetAddressLine2,
                        City = customer.Address.City,
                        State = customer.Address.State,
                        Zip = customer.Address.ZipCode.Zip,
                        Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                        Tag = string.IsNullOrEmpty(customer.Tag) ? "N/A" : customer.Tag,
                        MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                        IsGiftCertificateDelivered = eventCustomer.IsGiftCertificateDelivered,
                        GiftCode = eventCustomer.GiftCode,
                        Mrn = customer.Mrn
                    };

                    var order = orders.FirstOrDefault(o => o.EventId == eventCustomer.EventId && o.CustomerId == eventCustomer.CustomerId);
                    if (order != null)
                    {
                        var package = packages.FirstOrDefault(p => p.FirstValue == order.Id);

                        var test = tests.Where(p => p.FirstValue == order.Id).ToList();

                        var productPurchased = string.Empty;

                        if (package != null && !test.IsNullOrEmpty())
                            productPurchased = package.SecondValue + " + " + string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                        else if (!test.IsNullOrEmpty())
                            productPurchased = string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                        else if (package != null)
                            productPurchased = package.SecondValue;

                        customerExportModel.Package = productPurchased;
                    }

                    var eventModel = eventListModel.Collection.FirstOrDefault(e => e.EventCode == eventCustomer.EventId);
                    if (eventModel != null)
                    {
                        customerExportModel.EventId = eventModel.EventCode;
                        customerExportModel.EventName = eventModel.Location;
                        customerExportModel.EventDate = eventModel.EventDate;
                        customerExportModel.EventAddress1 = eventModel.StreetAddressLine1;
                        customerExportModel.EventAddress2 = eventModel.StreetAddressLine2;
                        customerExportModel.EventCity = eventModel.City;
                        customerExportModel.EventState = eventModel.State;
                        customerExportModel.EventZip = eventModel.Zip;
                        customerExportModel.Pod = eventModel.Pod;
                    }
                    customerExportModels.Add(customerExportModel);
                }
            }

            model.Collection = customerExportModels;
            return model;
        }
    }
}
