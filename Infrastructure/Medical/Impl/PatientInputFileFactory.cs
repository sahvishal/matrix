using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PatientInputFileFactory : IPatientInputFileFactory
    {
        public PatientInputFileViewModel Create(Customer customer, Event eventData, string serialKey, PrimaryCarePhysician primaryCarePhysician)
        {
            var model = new PatientInputFileViewModel
            {
                PatientCid = customer.InsuranceId,
                OrdDate = eventData.EventDate,
                //LocationName = eventData.Name,
                FirstName = customer.Name.FirstName,
                MiddleName = string.IsNullOrEmpty(customer.Name.MiddleName) ? string.Empty : customer.Name.MiddleName.Substring(0, 1),
                LastName = customer.Name.LastName,
                Address = customer.Address,
                PhoneHome = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.ToString() : string.Empty,
                //EmailHome = customer.Email != null ? customer.Email.ToString() : string.Empty,
                Gender = customer.Gender == Gender.Male ? "M" : customer.Gender == Gender.Female ? "F" : string.Empty,
                DateOfBirth = customer.DateOfBirth,
                LanguageSpoken = string.Empty,
                BoxCode = serialKey,
                TestModel = "FIT",
                Custom1 = "Healthfair",
                Custom2 = customer.CustomerId.ToString()
            };

            if (primaryCarePhysician != null)
            {
                model.PcpName = primaryCarePhysician.Name.ToString();
                model.PcpPhone = primaryCarePhysician.Primary != null ? primaryCarePhysician.Primary.ToString() : string.Empty;
                model.PcpFax = primaryCarePhysician.Fax != null ? primaryCarePhysician.Fax.ToString() : string.Empty;
                model.PcpAddress = primaryCarePhysician.Address;
            }

            return model;
        }
    }
}
