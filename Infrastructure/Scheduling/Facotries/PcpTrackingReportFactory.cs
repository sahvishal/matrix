using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class PcpTrackingReportFactory : IPcpTrackingReportFactory
    {
        public IEnumerable<PcpTrackingReportViewModel> Create(IEnumerable<Customer> customers, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians,
            IEnumerable<CorporateAccount> corporateAccounts, IEnumerable<Organization> organizations)
        {
            var collection = new List<PcpTrackingReportViewModel>();
            foreach (var customer in customers)
            {
                var customerPcps = primaryCarePhysicians.Where(x => x.CustomerId == customer.CustomerId)
                    .OrderByDescending(x => x.DataRecorderMetaData.DateCreated);

                if (!customerPcps.IsNullOrEmpty())
                {
                    var uploadedPcp = customerPcps.First(x => x.Source == (long)CustomerPcpUpdateSource.CorporateUpload);

                    var updatedPcp = customerPcps.FirstOrDefault(x => x.Source != (long)CustomerPcpUpdateSource.CorporateUpload
                        && x.DataRecorderMetaData.DateCreated > uploadedPcp.DataRecorderMetaData.DateCreated);

                    var healthPlan = corporateAccounts.FirstOrDefault(x => x.Tag == customer.Tag);
                    var organization = healthPlan != null ? organizations.First(x => x.Id == healthPlan.Id) : null;

                    var model = new PcpTrackingReportViewModel
                    {
                        PatientId = customer.CustomerId,
                        PatientName = customer.NameAsString,
                        HealthPlan = organization != null ? organization.Name : "NA",
                        PcpName = uploadedPcp.Name.ToString(),
                        PcpAddress = uploadedPcp.Address != null ? uploadedPcp.Address.ToString() : "NA",
                        PcpEmail = uploadedPcp.Email != null ? uploadedPcp.Email.ToString() : "NA",
                        PcpPhone = uploadedPcp.Primary != null ? uploadedPcp.Primary.FormatPhoneNumber : "NA",
                        IsUpdated = "No"
                    };
                    if (updatedPcp != null)
                    {
                        model.IsUpdated = "Yes";
                        model.NewPcpName = updatedPcp.Name.ToString();
                        model.NewPcpAddress = updatedPcp.Address != null ? updatedPcp.Address.ToString() : "NA";
                        model.NewPcpEmail = updatedPcp.Email != null ? updatedPcp.Email.ToString() : "NA";
                        model.NewPcpPhone = updatedPcp.Primary != null ? updatedPcp.Primary.FormatPhoneNumber : "NA";
                    }

                    collection.Add(model);
                }
            }

            return collection;
        }
    }
}
