using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;
using System.Linq;
using DateTime = System.DateTime;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class HealthPlanExportCustomerViewModelFactory : IHealthPlanExportCustomerViewModelFactory
    {
        public List<HealthPlanExportCustomerViewModel> Create(IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> corporateCustomerCustomTags, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians)
        {
            var exportcustomerList = new List<HealthPlanExportCustomerViewModel>();
            customers.ForEach(customer =>
            {
                var customerCustomTags = corporateCustomerCustomTags.Where(x => x.CustomerId == customer.CustomerId);
                var customTags = customerCustomTags.IsNullOrEmpty() ? "" : string.Join(",", customerCustomTags.Select(x => x.Tag));

                var pcp = primaryCarePhysicians.Where(p => p.CustomerId == customer.CustomerId).Select(p => p).FirstOrDefault();

                var hp = new HealthPlanExportCustomerViewModel()
                {
                    CustomerId = customer.CustomerId,
                    CustomerCode = customer.CustomerId.ToString(),
                    CustomerName = customer.Name,
                    Address = customer.Address,
                    Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                    Phone = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.FormatPhoneNumber : string.Empty,
                    PhoneCell = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.FormatPhoneNumber : string.Empty,
                    PhoneOffice = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.FormatPhoneNumber : string.Empty,
                    DoB = customer.DateOfBirth,
                    CustomTag = customTags,
                    MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                    Hicn = string.IsNullOrEmpty(customer.Hicn) ? "N/A" : customer.Hicn,
                    PcpName = pcp != null && pcp.Name != null ? pcp.Name.FullName : string.Empty,
                    PcpPhone = pcp != null && pcp.Primary != null ? pcp.Primary.ToString() : string.Empty,
                    Mrn = string.IsNullOrEmpty(customer.Mrn) ? string.Empty : customer.Mrn,
                    GroupName = string.IsNullOrEmpty(customer.GroupName) ? string.Empty : customer.GroupName
                };

                exportcustomerList.Add(hp);
            });
            return exportcustomerList;
        }

        public List<BcbsMiIncorrectPhoneViewModel> CreateIncorrectPhoneListForBcbsMi(IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> corporateCustomerCustomTags, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<DateAddedSettings> dateAddedSettings = null)
        {
            var exportcustomerList = new List<BcbsMiIncorrectPhoneViewModel>();
            customers.ForEach(customer =>
            {
                var customerCustomTags = corporateCustomerCustomTags.Where(x => x.CustomerId == customer.CustomerId);
                var customTags = customerCustomTags.IsNullOrEmpty() ? "" : string.Join(",", customerCustomTags.Select(x => x.Tag));

                var pcp = primaryCarePhysicians.Where(p => p.CustomerId == customer.CustomerId).Select(p => p).FirstOrDefault();

                var addedDate = (DateTime?)null;
                if (!dateAddedSettings.IsNullOrEmpty())
                {
                    addedDate = dateAddedSettings.Where(p => p.CustomerId == customer.CustomerId).Select(p => p.AddedDate).FirstOrDefault();
                }

                /*var isMarkedThisWeek = false;

                var customerMarkedIncorrectThisWeek = markedIncorrectThisWeek as long[] ?? markedIncorrectThisWeek.ToArray();
                if (!customerMarkedIncorrectThisWeek.IsNullOrEmpty() && customerMarkedIncorrectThisWeek.Any(s => s == customer.CustomerId))
                    isMarkedThisWeek = true;*/

                var hp = new BcbsMiIncorrectPhoneViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerCode = customer.CustomerId.ToString(),
                    CustomerName = customer.Name,
                    Address = customer.Address,
                    Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                    Phone = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.FormatPhoneNumber : string.Empty,
                    PhoneCell = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.FormatPhoneNumber : string.Empty,
                    PhoneOffice = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.FormatPhoneNumber : string.Empty,
                    CustomTag = customTags,
                    MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                    Hicn = string.IsNullOrEmpty(customer.Hicn) ? "N/A" : customer.Hicn,
                    PcpName = pcp != null && pcp.Name != null ? pcp.Name.FullName : string.Empty,
                    PcpPhone = pcp != null && pcp.Primary != null ? pcp.Primary.ToString() : string.Empty,
                    Market = customer.Market,
                    DOB = customer.DateOfBirth,
                    GroupName = string.IsNullOrEmpty(customer.GroupName) ? string.Empty : customer.GroupName,
                    DateAddedtoReport = addedDate ?? DateTime.Today,

                    /*MarkedIncorrectThisWeek = isMarkedThisWeek ? "Yes" : "No",
                    MarkedRecently = isMarkedThisWeek*/
                };

                exportcustomerList.Add(hp);
            });
            return exportcustomerList;
        }

        public List<BcbsMiHomeVisitRequestViewModel> CreateHomeVisitListForBcbsMi(IEnumerable<Customer> customers, IEnumerable<CorporateCustomerCustomTag> corporateCustomerCustomTags, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians)
        {
            var exportcustomerList = new List<BcbsMiHomeVisitRequestViewModel>();
            customers.ForEach(customer =>
            {
                var customerCustomTags = corporateCustomerCustomTags.Where(x => x.CustomerId == customer.CustomerId);
                var customTags = customerCustomTags.IsNullOrEmpty() ? "" : string.Join(",", customerCustomTags.Select(x => x.Tag));

                var pcp = primaryCarePhysicians.Where(p => p.CustomerId == customer.CustomerId).Select(p => p).FirstOrDefault();

                var hp = new BcbsMiHomeVisitRequestViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerCode = customer.CustomerId.ToString(),
                    CustomerName = customer.Name,
                    Address = customer.Address,
                    Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                    Phone = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.FormatPhoneNumber : string.Empty,
                    PhoneCell = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.FormatPhoneNumber : string.Empty,
                    PhoneOffice = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.FormatPhoneNumber : string.Empty,
                    CustomTag = customTags,
                    MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                    Hicn = string.IsNullOrEmpty(customer.Hicn) ? "N/A" : customer.Hicn,
                    PcpName = pcp != null && pcp.Name != null ? pcp.Name.FullName : string.Empty,
                    PcpPhone = pcp != null && pcp.Primary != null ? pcp.Primary.ToString() : string.Empty,
                    Market = customer.Market
                };

                exportcustomerList.Add(hp);
            });
            return exportcustomerList;
        }
    }
}
