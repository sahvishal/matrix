using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class BiWeeklyMicroAlbuminFobtReportFactory : IBiWeeklyMicroAlbuminFobtReportFactory
    {
        private const string Yes = "Y";
        private const string EmptyString = "";
        private const string NotAvailable = "N/A";

        public BiWeeklyMicroAlbuminFobtReportViewModel CreateModel(Customer customer, DateTime eventDate, bool fobtKit, bool microAlbuminKit, PhysicianLabTest physicianLabtest)
        {
            return new BiWeeklyMicroAlbuminFobtReportViewModel
            {
                Market = customer.Market,
                MemberId = customer.InsuranceId,
                Gmpi = customer.AdditionalField3,                   //as report is for Wellmed , GMPI is AdditionalField3
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                EventDate = eventDate.ToShortDateString(),
                FobtKit = fobtKit ? Yes : EmptyString,
                MicroalbuminKit = microAlbuminKit ? Yes : EmptyString,
                LabAccountNumber = physicianLabtest != null ? physicianLabtest.IfobtLicenseNo : NotAvailable,  //till date & as discussed ,both ifobt and microalbumin's licenseNo were same
                HfComment = EmptyString
            };
        }
    }
}
