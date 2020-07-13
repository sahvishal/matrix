using System;
using System.Globalization;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.OutboundReport.Enum;
using Falcon.App.Core.OutboundReport.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.OutboundReport.Impl
{
    [DefaultImplementation]
    public class ChaseOutboundFactory : IChaseOutboundFactory
    {
        private readonly IUserRepository<User> _userRepository;
        private int count = 0;

        public ChaseOutboundFactory(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public ChaseOutbound Create(ChaseOutboundViewModel model)
        {
            return new ChaseOutbound
            {
                TenantId = model.TenantId,
                IndividualId = model.IndividualId,
                ClientId = model.ClientId,
                VendorCd = model.VendorCD,
                ContractNumber = model.ContractNumber,
                ContractPersonNumber = model.ContractPersonNumber,
                ConsumerId = model.ConsumerId,
                CampaignMemberId = model.CampaignMemberId,
                DistributionId = model.DistributionId,
                SubscriberIndicator = model.SubscriberIndicator,
                IdentifiedIndicator = model.IdentifiedIndicator,
                OutboundCallIndicator = model.OutboundCallIndicator,
                WirelessIndicator = model.WirelessIndicator,
                PriorityCode = model.PriorityCode,
                BusinessCaseId = model.BusinessCaseId,
                MedicareIndicator = model.MedicareIndicator,
                HmoLobIndicator = model.HmoLobIndicator,
                ReferMemberTo = model.ReferMemberTo,
                ClosestRetailCenter = model.ClosestRetailCenter,
                ConfidenceScoreId = !string.IsNullOrEmpty(model.ConfidenceScore) ? (long)((ConfidenceScore)Enum.Parse(typeof(ConfidenceScore), model.ConfidenceScore, true)) : (long?)null,
                LocationCode = model.LocationCode,
                AgentContextNameValueSet = model.AgentContextNameValueSet,
                DateCreated = DateTime.Now,
                IsActive = true
            };
        }

        public Customer CreateCustomer(ChaseOutboundViewModel model, Customer customer, Language language, string tag)
        {
            if (customer == null)
                customer = new Customer
                {
                    Address = new Address(),
                    AddedByRoleId = (long)Roles.FranchiseeAdmin
                };

            customer.InsuranceId = model.IndividualId;
            customer.Name = new Name
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleInitial,
                LastName = model.LastName
            };
            if (!string.IsNullOrEmpty(model.GenderCode))
            {
                var genderCode = !string.IsNullOrEmpty(model.GenderCode) ? model.GenderCode == "M" ? "Male" : model.GenderCode == "F" ? "Female" : "Unspecified" : "Unspecified";
                customer.Gender = (Gender)Enum.Parse(typeof(Gender), genderCode, true);
            }

            if (!string.IsNullOrEmpty(model.DateOfBirth))
            {
                customer.DateOfBirth = Convert.ToDateTime(model.DateOfBirth);
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                string[] emailSplitUp = model.Email.Split(new[] { '@' });
                customer.Email = new Email { Address = emailSplitUp[0], DomainName = emailSplitUp[1] };
            }

            customer.Address.CountryId = (long)CountryCode.UnitedStatesAndCanada;
            customer.Address.StreetAddressLine1 = model.AddressLine1;
            customer.Address.StreetAddressLine2 = model.AddressLine2;
            customer.Address.City = model.AddressCity;
            customer.Address.CityId = 0;
            customer.Address.State = model.AddressState;
            customer.Address.StateId = 0;
            customer.Address.ZipCode = new ZipCode(model.AddressZipCode);
            customer.Tag = tag;

            if (customer.UserLogin == null)
            {
                customer.UserLogin = new UserLogin
                {
                    UserName = GenerateUniqueUserName(model.FirstName + "." + model.LastName),
                    Password = GenerateUniquePassword(),
                    IsSecurityQuestionVerified = false,
                    UserVerified = false
                };
            }

            if (!string.IsNullOrEmpty(model.LanguagePreferenceCode))
            {
                if (language != null)
                    customer.LanguageId = language.Id;
            }

            return customer;
        }

        private string GenerateUniqueUserName(string userName)
        {
            if (!_userRepository.UserNameExists(userName))
                return userName;
            count++;
            return GenerateUniqueUserName(userName + count);
        }

        private string GenerateUniquePassword()
        {
            return RandomNumberHelper.Between(10000, 99999).ToString();
        }

        public CorporateCustomerEditModel CreateCorporateCustomerEditModel(ChaseOutboundViewModel model)
        {
            var pcpName = !string.IsNullOrEmpty(model.ProviderOfRecordFullName) ? model.ProviderOfRecordFullName.Split(',') : null;
            int languageCode;
            var corporateCustomerEditModel = new CorporateCustomerEditModel
            {
                MemberId = model.ContractNumber,
                FirstName = model.FirstName,
                MiddleName = model.MiddleInitial,
                LastName = model.LastName,
                Gender = !string.IsNullOrEmpty(model.GenderCode) ? model.GenderCode == "M" ? Gender.Male.ToString() : model.GenderCode == "F" ? Gender.Female.ToString() : Gender.Unspecified.ToString() : Gender.Unspecified.ToString(),
                Dob = model.DateOfBirth,//ChangeDateTimeFormat(model.DateOfBirth, "dd-MM-yyyy", "MM/dd/yyyy"),
                Email = model.Email,
                PhoneCell = model.WorkPhoneNumber,
                PhoneHome = model.PhoneNumber,
                Address1 = model.AddressLine1,
                Address2 = model.AddressLine2,
                City = model.AddressCity,
                State = model.AddressState,
                Zip = model.AddressZipCode.Length >= 5 ? model.AddressZipCode.Substring(0, 5) : model.AddressZipCode.PadLeft(5, '0'),
                PcpFirstName = pcpName != null ? pcpName.Last().Trim() : null,
                PcpLastName = pcpName != null && pcpName.Length > 1 ? pcpName.First().Trim() : null,
                PcpFax = "",
                PcpPhone = model.ProviderOfRecordPhoneNumber,
                Language = int.TryParse(model.LanguagePreferenceCode.Trim(), out languageCode) ? string.Empty : model.LanguagePreferenceCode,
                PCPMailingAddress1 = "",
                PCPMailingAddress2 = "",
                PCPMailingCity = "",
                PCPMailingState = "",
                PCPMailingZip = "",
                IsEligible = "Yes",
                TargetYear = DateTime.Now.Year.ToString(),
                Hicn = model.Hicn,
                Activity = UploadActivityType.BothMailAndCall.ToString()
            };

            if (!string.IsNullOrEmpty(model.HomeAddressLine1) && !string.IsNullOrEmpty(model.HomeAddressCity)
                && !string.IsNullOrEmpty(model.HomeAddressState) && !string.IsNullOrEmpty(model.HomeAddressZipCode))
            {
                corporateCustomerEditModel.Address1 = model.HomeAddressLine1;
                corporateCustomerEditModel.Address2 = model.HomeAddressLine2;
                corporateCustomerEditModel.City = model.HomeAddressCity;
                corporateCustomerEditModel.State = model.HomeAddressState;
                corporateCustomerEditModel.Zip = model.HomeAddressZipCode.Length >= 5 ? model.HomeAddressZipCode.Substring(0, 5) : model.HomeAddressZipCode.PadLeft(5, '0');
            }

            if (!string.IsNullOrWhiteSpace(model.ProviderOfRecordAddressZipCode))
            {
                corporateCustomerEditModel.PcpAddress1 = model.ProviderOfRecordAddressLine1;
                corporateCustomerEditModel.PcpAddress2 = model.ProviderOfRecordAddressLine2;
                corporateCustomerEditModel.PcpCity = model.ProviderOfRecordAddressCity;
                corporateCustomerEditModel.PcpState = model.ProviderOfRecordAddressState;
                corporateCustomerEditModel.PcpZip = model.ProviderOfRecordAddressZipCode.Length >= 5
                    ? model.ProviderOfRecordAddressZipCode.Substring(0, 5)
                    : model.ProviderOfRecordAddressZipCode.PadLeft(5, '0');
            }
            else
            {
                corporateCustomerEditModel.PcpAddress1 = "";
                corporateCustomerEditModel.PcpAddress2 = "";
                corporateCustomerEditModel.PcpCity = "";
                corporateCustomerEditModel.PcpState = "";
                corporateCustomerEditModel.PcpZip = "";
            }

            return corporateCustomerEditModel;
        }

        private string ChangeDateTimeFormat(string dateString, string currentFormat, string desiredformat)
        {
            var dateTime = DateTime.ParseExact(dateString, currentFormat, CultureInfo.InvariantCulture);
            return dateTime.ToString(desiredformat);
        }
    }
}
