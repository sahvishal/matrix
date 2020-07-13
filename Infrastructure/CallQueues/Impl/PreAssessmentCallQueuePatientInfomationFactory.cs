using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class PreAssessmentCallQueuePatientInfomationFactory : IPreAssessmentCallQueuePatientInfomationFactory
    {
        public CallQueueCustomerEditModel GetCallQueueCustomerEditModel(PreAssessmentCustomerContactViewModel model, bool isHealthPlanCallQueue)
        {
            var editModel = new CallQueueCustomerEditModel();

            editModel.CustomerId = model.PatientInfomation.CustomerId.Value;
            editModel.ProspectCustomerId = model.PatientInfomation.ProspectCustomerId.HasValue ? model.PatientInfomation.ProspectCustomerId.Value : 0;
            editModel.FirstName = model.PatientInfomation.FirstName;
            editModel.LastName = model.PatientInfomation.LastName;
            editModel.Gender = (int)model.PatientInfomation.Gender;
            editModel.Email = model.PatientInfomation.Email;
            editModel.AlternateEmail = model.PatientInfomation.AlternateEmail;
            editModel.UserId = model.PatientInfomation.UserId;
            editModel.DateOfBirth = model.PatientInfomation.DateOfBirth;
            editModel.CallId = model.CallId;
            editModel.CallQueueCustomerId = model.PatientInfomation.CallQueueCustomerId;
            editModel.CallBackPhoneNumber = model.PatientInfomation.CallBackPhoneNumber.FormatPhoneNumber;
            editModel.OfficePhoneNumber = model.PatientInfomation.OfficePhoneNumber.FormatPhoneNumber;
            editModel.MobilePhoneNumber = model.PatientInfomation.MobilePhoneNumber.FormatPhoneNumber;
            editModel.IsHealthPlanQueue = isHealthPlanCallQueue;
            editModel.Hicn = model.PatientInfomation.HicnNumber;
            editModel.Mbi = model.PatientInfomation.MbiNumber;

            editModel.MemberId = model.PatientInfomation.MemberId;

            editModel.ActivityId = model.PatientInfomation.ActivityId;

            editModel.Address = new AddressEditModel
            {
                City = model.PatientInfomation.AddressViewModel.City,
                CountryId = 1,
                StateId = model.PatientInfomation.AddressViewModel.StateId,
                StreetAddressLine1 = model.PatientInfomation.AddressViewModel.StreetAddressLine1,
                StreetAddressLine2 = model.PatientInfomation.AddressViewModel.StreetAddressLine2,
                ZipCode = model.PatientInfomation.AddressViewModel.ZipCode
            };


            if (model.PatientInfomation.PrimaryCarePhysician != null)
            {
                editModel.PrimaryCarePhysician = new Core.Medical.ViewModels.PrimaryCarePhysicianEditModel
                {
                    FullName = model.PatientInfomation.PrimaryCarePhysician.FullName,
                    Address = model.PatientInfomation.PrimaryCarePhysician.Address == null ? new AddressEditModel() { CountryId = 1 } : new AddressEditModel
                    {
                        City = model.PatientInfomation.PrimaryCarePhysician.Address.City,
                        CountryId = 1,
                        StreetAddressLine1 = model.PatientInfomation.PrimaryCarePhysician.Address.StreetAddressLine1,
                        StreetAddressLine2 = model.PatientInfomation.PrimaryCarePhysician.Address.StreetAddressLine2,
                        ZipCode = model.PatientInfomation.PrimaryCarePhysician.Address.ZipCode,
                        StateId = model.PatientInfomation.PrimaryCarePhysician.Address.StateId
                    },

                    MailingAddress = model.PatientInfomation.PrimaryCarePhysician.MailingAddress == null ? new AddressEditModel() { CountryId = 1 } : new AddressEditModel
                    {
                        City = model.PatientInfomation.PrimaryCarePhysician.MailingAddress.City,
                        CountryId = 1,
                        StreetAddressLine1 = model.PatientInfomation.PrimaryCarePhysician.MailingAddress.StreetAddressLine1,
                        StreetAddressLine2 = model.PatientInfomation.PrimaryCarePhysician.MailingAddress.StreetAddressLine2,
                        ZipCode = model.PatientInfomation.PrimaryCarePhysician.MailingAddress.ZipCode,
                        StateId = model.PatientInfomation.PrimaryCarePhysician.MailingAddress.StateId
                    },
                    Email = model.PatientInfomation.PrimaryCarePhysician.Email,
                    Phone = model.PatientInfomation.PrimaryCarePhysician.Phone,
                    HasSameAddress = model.PatientInfomation.PrimaryCarePhysician.HasSameAddress
                };
            }

            editModel.EnableEmail = model.PatientInfomation.EnableEmail;
            return editModel;
        }
        public CallQueuePatientInfomationViewModel SetCustomerInfo(Customer customer, CustomerEligibility customerEligibility, Falcon.App.Core.Medical.Domain.ActivityType activityType)
        {
            var address = customer.Address != null ? Mapper.Map<Address, AddressViewModel>(customer.Address) : customer.BillingAddress != null ? Mapper.Map<Address, AddressViewModel>(customer.BillingAddress) : null;
            bool? eligibility = null;
            if (customerEligibility != null && customerEligibility.IsEligible.HasValue)
            {
                eligibility = customerEligibility.IsEligible.Value;
            }
            var model = new CallQueuePatientInfomationViewModel
            {
                CustomerId = customer.CustomerId,
                UserId = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Gender = customer.Gender,
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email != null ? customer.Email.ToString() : string.Empty,
                AlternateEmail = customer.AlternateEmail != null ? customer.AlternateEmail.ToString() : string.Empty,
                HicnNumber = customer.Hicn,
                MbiNumber = customer.Mbi,
                MemberId = customer.InsuranceId,
                GroupName = customer.GroupName,
                IsEligible = eligibility,
                AddressViewModel = address,
                CallBackPhoneNumber = customer.HomePhoneNumber,
                OfficePhoneNumber = customer.OfficePhoneNumber,
                MobilePhoneNumber = customer.MobilePhoneNumber,
                ActivityId = activityType != null ? activityType.Id : 0,
                Activity = activityType != null ? activityType.Name : string.Empty,
                PhoneHomeConsent = customer.PhoneHomeConsentId,
                PhoneOfficeConsent = customer.PhoneOfficeConsentId,
                PhoneCellConsent = customer.PhoneCellConsentId,
                EnableEmail = customer.EnableEmail,
                AcesId = customer.AcesId,
                Product=customer.ProductTypeId.HasValue && customer.ProductTypeId.Value > 0 ? ((ProductType)customer.ProductTypeId.Value).GetDescription() : "N/A"
            };

            return model;
        }

        public CallQueuePatientInfomationViewModel SetProspectCustomerInfo(ProspectCustomer domain)
        {
            var address = domain.Address != null ? Mapper.Map<Address, AddressViewModel>(domain.Address) : null;

            var model = new CallQueuePatientInfomationViewModel
            {
                ProspectCustomerId = domain.Id,
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                Gender = domain.Gender,
                DateOfBirth = domain.BirthDate,
                Email = domain.Email != null ? domain.Email.ToString() : string.Empty,
                AddressViewModel = address,
                CallBackPhoneNumber = domain.CallBackPhoneNumber,
            };

            return model;
        }
        public CallQueuePatientInfomationViewModel SetCustomerTagInfo(ProspectCustomer domain, CallQueuePatientInfomationViewModel model)
        {
            if (domain == null)
            {
                model.ContactType = CallQueueTypeOfContact.Prospect.GetDescription();
                model.ProspectTag = "Annual Customers";
            }
            else
            {
                if (domain.Tag.GetDescription() == ProspectCustomerTag.OnlineSignup.GetDescription())
                {
                    model.ContactType = CallQueueTypeOfContact.WebProspect.GetDescription();
                }
                else
                {
                    model.ContactType = CallQueueTypeOfContact.Prospect.GetDescription();
                }

                model.ProspectTag = domain.Tag.GetDescription() == ProspectCustomerTag.Unspecified.GetDescription() ? "Annual Customers" : domain.Tag.GetDescription();
            }


            return model;
        }

    }
}
