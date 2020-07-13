using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;

namespace Falcon.App.Infrastructure.Users.Factories
{
    [DefaultImplementation]
    public class MemberUploadParseDetailFactory : IMemberUploadParseDetailFactory
    {
        public MemberUploadParseDetail GetDomain(CorporateCustomerEditModel viewModel, long corporateUploadId)
        {
            var domain = new MemberUploadParseDetail();

            domain.AcesId = viewModel.AcesId;
            domain.Activity = viewModel.Activity;
            domain.AdditionalField1 = viewModel.AdditionalField1;
            domain.AdditionalField2 = viewModel.AdditionalField2;
            domain.AdditionalField3 = viewModel.AdditionalField3;
            domain.AdditionalField4 = viewModel.AdditionalField4;
            domain.Address1 = viewModel.Address1;
            domain.Address2 = viewModel.Address2;
            domain.AlternateEmail = viewModel.AlternateEmail;
            domain.BillingMemberId = viewModel.BillingMemberId;
            domain.BillingMemberPlan = viewModel.BillingMemberPlan;
            domain.BillingMemberPlanYear = viewModel.BillingMemberPlanYear.HasValue ? viewModel.BillingMemberPlanYear.Value.ToString() : string.Empty;
            domain.City = viewModel.City;
            domain.Copay = viewModel.Copay;
            domain.CurrentMedication = viewModel.CurrentMedication != null ? string.Join(",", viewModel.CurrentMedication) : string.Empty;
            domain.CurrentMedicationSource = viewModel.CurrentMedicationSource != null ? string.Join(",", viewModel.CurrentMedicationSource) : string.Empty;
            domain.CustomerId = viewModel.CustomerId;
            domain.Dob = viewModel.Dob;
            domain.Email = viewModel.Email;
            domain.ErrorMessage = viewModel.ErrorMessage;
            domain.FirstName = viewModel.FirstName;
            domain.Gender = viewModel.Gender;
            domain.GroupName = viewModel.GroupName;
            domain.Hicn = viewModel.Hicn;
            domain.IcdCodes = viewModel.IcdCodes != null ? string.Join(",", viewModel.IcdCodes) : string.Empty;
            domain.IsEligible = viewModel.IsEligible;
            domain.Lab = viewModel.Lab;
            domain.Language = viewModel.Language;
            domain.LastName = viewModel.LastName;
            domain.Lpi = viewModel.Lpi;
            domain.Market = viewModel.Market;
            domain.Mbi = viewModel.Mbi;
            domain.MedicareAdvantagePlanName = viewModel.MedicareAdvantagePlanName;
            domain.MemberId = viewModel.MemberId;
            domain.MiddleName = viewModel.MiddleName;
            domain.Mrn = viewModel.Mrn;
            domain.PcpAddress1 = viewModel.PcpAddress1;
            domain.PcpAddress2 = viewModel.PcpAddress2;
            domain.PcpCity = viewModel.PcpCity;
            domain.PcpEmail = viewModel.PcpEmail;
            domain.PcpFax = viewModel.PcpFax;
            domain.PcpFirstName = viewModel.PcpFirstName;
            domain.PcpLastName = viewModel.PcpLastName;
            domain.PCPMailingAddress1 = viewModel.PCPMailingAddress1;
            domain.PCPMailingAddress2 = viewModel.PCPMailingAddress2;
            domain.PCPMailingCity = viewModel.PCPMailingCity;
            domain.PCPMailingState = viewModel.PCPMailingState;
            domain.PCPMailingZip = viewModel.PCPMailingZip;
            domain.PcpNpi = viewModel.PcpNpi;
            domain.PcpPhone = viewModel.PcpPhone;
            domain.PcpState = viewModel.PcpState;
            domain.PcpZip = viewModel.PcpZip;
            domain.PhoneCell = viewModel.PhoneCell;
            domain.PhoneHome = viewModel.PhoneCell;
            domain.PreApprovedPackage = viewModel.PreApprovedPackage;
            domain.PreApprovedPackageId = viewModel.PreApprovedPackageId > 0 ? viewModel.PreApprovedPackageId : (long?)null;
            domain.PreApprovedTest = viewModel.PreApprovedTest != null ? string.Join(",", viewModel.PreApprovedTest) : string.Empty;
            domain.PredictedZip = viewModel.PredictedZip;
            domain.State = viewModel.State;
            domain.TargetYear = viewModel.TargetYear;
            domain.WarmTransferAllowed = viewModel.WarmTransferAllowed;
            domain.WarmTransferYear = viewModel.WarmTransferYear;
            domain.Zip = viewModel.Zip;
            domain.CorporateUploadId = corporateUploadId;
            domain.IsSuccessful = string.IsNullOrWhiteSpace(viewModel.ErrorMessage) ? true : false;
            domain.EligibilityYear = viewModel.EligibilityYear;
            domain.DNC = viewModel.DNCFlag;
            domain.ProductType = viewModel.Product;

            domain.AcesClientId = viewModel.ACESClientID;

            return domain;
        }

        public CorporateCustomerEditModel GetCorporateCustomerModel(MemberUploadParseDetail domain, long? memberUplaodsourceId)
        {
            var model = new CorporateCustomerEditModel();

            model.AcesId = domain.AcesId;
            model.Activity = domain.Activity;
            model.AdditionalField1 = domain.AdditionalField1;
            model.AdditionalField2 = domain.AdditionalField2;
            model.AdditionalField3 = domain.AdditionalField3;
            model.AdditionalField4 = domain.AdditionalField4;
            model.Address1 = domain.Address1;
            model.Address2 = domain.Address2;
            model.AlternateEmail = domain.AlternateEmail;
            model.BillingMemberId = domain.BillingMemberId;
            model.BillingMemberPlan = domain.BillingMemberPlan;
            model.BillingMemberPlanYear = !string.IsNullOrWhiteSpace(domain.BillingMemberPlanYear) ? Convert.ToInt32(domain.BillingMemberPlanYear) : (int?)null;
            model.City = domain.City;
            model.Copay = domain.Copay;
            model.CurrentMedication = !string.IsNullOrWhiteSpace(domain.CurrentMedication) ? domain.CurrentMedication.Split(new char[] { ',' }) : null;
            model.CurrentMedicationSource = !string.IsNullOrWhiteSpace(domain.CurrentMedicationSource) ? domain.CurrentMedicationSource.Split(new char[] { ',' }) : null;
            model.CustomerId = domain.CustomerId;
            model.Dob = domain.Dob;
            model.Email = domain.Email;
            model.ErrorMessage = domain.ErrorMessage;
            model.FirstName = domain.FirstName;
            model.Gender = domain.Gender;
            model.GroupName = domain.GroupName;
            model.Hicn = domain.Hicn;
            model.IcdCodes = !string.IsNullOrWhiteSpace(domain.IcdCodes) ? domain.IcdCodes.Split(new char[] { ',' }) : null;
            model.IsEligible = domain.IsEligible;
            model.Lab = domain.Lab;
            model.Language = domain.Language;
            model.LastName = domain.LastName;
            model.Lpi = domain.Lpi;
            model.Market = domain.Market;
            model.Mbi = domain.Mbi;
            model.MedicareAdvantagePlanName = domain.MedicareAdvantagePlanName;
            model.MemberId = domain.MemberId;
            model.MemberUploadSourceId = memberUplaodsourceId;
            model.MiddleName = domain.MiddleName;
            model.Mrn = domain.Mrn;
            model.PcpAddress1 = domain.PcpAddress1;
            model.PcpAddress2 = domain.PcpAddress2;
            model.PcpCity = domain.PcpCity;
            model.PcpEmail = domain.PcpEmail;
            model.PcpFax = domain.PcpFax;
            model.PcpFirstName = domain.PcpFirstName;
            model.PcpLastName = domain.PcpLastName;
            model.PCPMailingAddress1 = domain.PCPMailingAddress1;
            model.PCPMailingAddress2 = domain.PCPMailingAddress2;
            model.PCPMailingCity = domain.PCPMailingCity;
            model.PCPMailingState = domain.PCPMailingState;
            model.PCPMailingZip = domain.PCPMailingZip;
            model.PcpNpi = domain.PcpNpi;
            model.PcpPhone = domain.PcpPhone;
            model.PcpState = domain.PcpState;
            model.PcpZip = domain.PcpZip;
            model.PhoneCell = domain.PhoneCell;
            model.PhoneHome = domain.PhoneCell;
            model.PreApprovedPackage = domain.PreApprovedPackage;
            model.PreApprovedPackageId = domain.PreApprovedPackageId.HasValue ? domain.PreApprovedPackageId.Value : 0;
            model.PreApprovedTest = !string.IsNullOrWhiteSpace(domain.PreApprovedTest) ? domain.PreApprovedTest.Split(new char[] { ',' }) : null;
            model.PredictedZip = domain.PredictedZip;
            model.State = domain.State;
            model.TargetYear = domain.TargetYear;
            model.WarmTransferAllowed = domain.WarmTransferAllowed;
            model.WarmTransferYear = domain.WarmTransferYear;
            model.Zip = domain.Zip;
            model.EligibilityYear = domain.EligibilityYear;
            model.DNCFlag = domain.DNC;
            model.Product = domain.ProductType;
            model.ACESClientID = domain.AcesClientId;
            return model;
        }

        public IEnumerable<CorporateCustomerEditModel> GetCorporateCustomerListModel(IEnumerable<MemberUploadParseDetail> domainList, long? memberUplaodsourceId)
        {
            var listModel = new List<CorporateCustomerEditModel>();

            if (domainList == null) return listModel;

            foreach (var domain in domainList)
            {
                listModel.Add(GetCorporateCustomerModel(domain, memberUplaodsourceId));
            }
            return listModel;
        }

        private MemberUploadbyAcesFailedCustomerModel GetMemberUploadbyAcesFailedCustomerModel(MemberUploadParseDetail domain, long? memberUplaodsourceId)
        {
            var model = new MemberUploadbyAcesFailedCustomerModel();

            model.AcesId = domain.AcesId;
            model.Activity = domain.Activity;
            model.AdditionalField1 = domain.AdditionalField1;
            model.AdditionalField2 = domain.AdditionalField2;
            model.AdditionalField3 = domain.AdditionalField3;
            model.AdditionalField4 = domain.AdditionalField4;
            model.Address1 = domain.Address1;
            model.Address2 = domain.Address2;
            model.AlternateEmail = domain.AlternateEmail;
            model.City = domain.City;
            model.Copay = domain.Copay;
            model.CurrentMedication = domain.CurrentMedication;
            model.CurrentMedicationSource = domain.CurrentMedicationSource;
            model.CustomerId = domain.CustomerId;
            model.Dob = domain.Dob;
            model.Email = domain.Email;
            model.ErrorMessage = domain.ErrorMessage;
            model.FirstName = domain.FirstName;
            model.Gender = domain.Gender;
            model.GroupName = domain.GroupName;
            model.Hicn = domain.Hicn;
            model.IcdCodes = domain.IcdCodes;
            model.IsEligible = domain.IsEligible;
            model.Lab = domain.Lab;
            model.Language = domain.Language;
            model.LastName = domain.LastName;
            model.Lpi = domain.Lpi;
            model.Market = domain.Market;
            model.Mbi = domain.Mbi;
            model.MedicareAdvantagePlanName = domain.MedicareAdvantagePlanName;
            model.MemberId = domain.MemberId;
            model.MemberUploadSourceId = memberUplaodsourceId;
            model.MiddleName = domain.MiddleName;
            model.Mrn = domain.Mrn;
            model.PcpAddress1 = domain.PcpAddress1;
            model.PcpAddress2 = domain.PcpAddress2;
            model.PcpCity = domain.PcpCity;
            model.PcpEmail = domain.PcpEmail;
            model.PcpFax = domain.PcpFax;
            model.PcpFirstName = domain.PcpFirstName;
            model.PcpLastName = domain.PcpLastName;
            model.PCPMailingAddress1 = domain.PCPMailingAddress1;
            model.PCPMailingAddress2 = domain.PCPMailingAddress2;
            model.PCPMailingCity = domain.PCPMailingCity;
            model.PCPMailingState = domain.PCPMailingState;
            model.PCPMailingZip = domain.PCPMailingZip;
            model.PcpNpi = domain.PcpNpi;
            model.PcpPhone = domain.PcpPhone;
            model.PcpState = domain.PcpState;
            model.PcpZip = domain.PcpZip;
            model.PhoneCell = domain.PhoneCell;
            model.PhoneHome = domain.PhoneCell;
            model.PreApprovedPackage = domain.PreApprovedPackage;
            model.PreApprovedPackageId = domain.PreApprovedPackageId.HasValue ? domain.PreApprovedPackageId.Value : 0;
            model.PreApprovedTest = domain.PreApprovedTest;
            model.PredictedZip = domain.PredictedZip;
            model.State = domain.State;
            model.TargetYear = domain.TargetYear;
            model.Zip = domain.Zip;
            model.EligibilityYear = domain.EligibilityYear;
            model.DNC = domain.DNC;
            model.ProductType = domain.ProductType;

            model.ACESClientID = domain.AcesClientId;
            //model.WarmTransferAllowed = domain.WarmTransferAllowed;
            //model.WarmTransferYear = domain.WarmTransferYear;
            //model.BillingMemberId = domain.BillingMemberId;
            //model.BillingMemberPlan = domain.BillingMemberPlan;
            //model.BillingMemberPlanYear = !string.IsNullOrWhiteSpace(domain.BillingMemberPlanYear) ? Convert.ToInt32(domain.BillingMemberPlanYear) : (int?)null;

            return model;
        }

        public List<MemberUploadbyAcesFailedCustomerModel> GetMemberUploadbyAcesFailedCustomerListModel(IEnumerable<MemberUploadParseDetail> domainList, long? memberUplaodsourceId)
        {
            var listModel = new List<MemberUploadbyAcesFailedCustomerModel>();

            if (domainList == null) return listModel;

            foreach (var domain in domainList)
            {
                listModel.Add(GetMemberUploadbyAcesFailedCustomerModel(domain, memberUplaodsourceId));
            }
            return listModel;
        }

    }
}
