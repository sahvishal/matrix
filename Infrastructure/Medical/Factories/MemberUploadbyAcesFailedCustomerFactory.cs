using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class MemberUploadbyAcesFailedCustomerFactory : IMemberUploadbyAcesFailedCustomerFactory
    {
        public MemberUploadbyAcesFailedCustomerModel Create(CorporateCustomerEditModel model)
        {
            return new MemberUploadbyAcesFailedCustomerModel
            {

                Activity = model.Activity,
                AdditionalField1 = model.AdditionalField1,
                AdditionalField2 = model.AdditionalField2,
                AdditionalField3 = model.AdditionalField3,
                AdditionalField4 = model.AdditionalField4,
                Address1 = model.Address1,
                Address2 = model.Address2,
                AlternateEmail = model.AlternateEmail,

                City = model.City,
                Copay = model.Copay,
                CurrentMedication = model.CurrentMedication.IsNullOrEmpty() ? string.Empty : string.Join(",", model.CurrentMedication),
                CurrentMedicationSource = model.CurrentMedicationSource.IsNullOrEmpty() ? string.Empty : string.Join(",", model.CurrentMedicationSource),
                Dob = model.Dob,
                Email = model.Email,
                ErrorMessage = model.ErrorMessage,
                FirstName = model.FirstName,
                Gender = model.Gender,
                GroupName = model.GroupName,
                Hicn = model.Hicn,
                IcdCodes = model.IcdCodes.IsNullOrEmpty() ? string.Empty : string.Join(",", model.IcdCodes),
                IsEligible = model.IsEligible,
                Lab = model.Lab,
                Language = model.Language,
                LastName = model.LastName,
                Lpi = model.Lpi,
                Market = model.Market,
                Mbi = model.Mbi,
                MedicareAdvantagePlanName = model.MedicareAdvantagePlanName,
                MemberId = model.MemberId,
                MemberUploadSourceId = model.MemberUploadSourceId,
                MiddleName = model.MiddleName,
                Mrn = model.Mrn,
                PcpAddress1 = model.PcpAddress1,
                PcpAddress2 = model.PcpAddress2,
                PcpCity = model.PcpCity,
                PcpEmail = model.PcpEmail,
                PcpFax = model.PcpFax,
                PcpFirstName = model.PcpFirstName,
                PcpLastName = model.PcpLastName,
                PCPMailingAddress1 = model.PCPMailingAddress1,
                PCPMailingAddress2 = model.PCPMailingAddress2,
                PCPMailingCity = model.PCPMailingCity,
                PCPMailingState = model.PCPMailingState,
                PCPMailingZip = model.PCPMailingZip,
                PcpNpi = model.PcpNpi,
                PcpPhone = model.PcpPhone,
                PcpState = model.PcpState,
                PcpZip = model.PcpZip,
                PhoneCell = model.PhoneCell,
                PhoneHome = model.PhoneHome,
                PreApprovedPackage = model.PreApprovedPackage,
                PreApprovedPackageId = model.PreApprovedPackageId,
                PreApprovedTest = model.PreApprovedTest.IsNullOrEmpty() ? string.Empty : string.Join(",", model.PreApprovedTest),
                PredictedZip = model.PredictedZip,
                State = model.State,
                TargetYear = model.TargetYear,
                Zip = model.Zip,
                AcesId = model.AcesId,
                EligibilityYear = model.EligibilityYear,
                //BillingMemberId = model.BillingMemberId,
                //BillingMemberPlan = model.BillingMemberPlan,
                //BillingMemberPlanYear = model.BillingMemberPlanYear,
                //WarmTransferAllowed = model.WarmTransferAllowed,
                //WarmTransferYear = model.WarmTransferYear,

            };
        }
    }
}
