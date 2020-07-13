using System;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Scheduling.Impl
{
    public class MassRegistrationEditModelFactory : IMassRegistrationEditModelFactory
    {
        private readonly IUserRepository<User> _userRepository;

        public MassRegistrationEditModelFactory(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Customer CreateCustomer(MassRegistrationEditModel model, OrganizationRoleUser createdByOrgRoleUser)
        {
            var customer = new Customer();
            customer.Name = new Name
                              {
                                  FirstName = model.FirstName,
                                  LastName = model.LastName
                              };
            customer.HomePhoneNumber = model.HomeNumber;
            if (!string.IsNullOrEmpty(model.Email))
            {
                string[] emailSplitUp = model.Email.Split(new[] { '@' });
                customer.Email = new Email { Address = emailSplitUp[0], DomainName = emailSplitUp[1] };
            }
            customer.Address = Mapper.Map<AddressEditModel, Address>(model.Address);
            customer.UserLogin = new UserLogin
                                   {
                                       UserName = GenerateUniqueUserName(model.FirstName + "." + model.LastName),
                                       Password = GenerateUniquePassword(),
                                       IsSecurityQuestionVerified = false,
                                       UserVerified = false
                                   };
            customer.Gender = (Gender)model.Gender;

            if (model.DateOfBirth.HasValue)
                customer.DateOfBirth = model.DateOfBirth;

            customer.AddedByRoleId = createdByOrgRoleUser.RoleId;
            customer.EmployeeId = model.EmployeeId;
            customer.InsuranceId = model.InsuranceId;
            if (!string.IsNullOrEmpty(model.Ssn))
                customer.Ssn = model.Ssn.Replace("-", "");

            var height = new Height(model.HeightInFeet, model.HeightInInch);
            customer.Height = height.TotalInches > 0 ? height : null;

            if (model.Weight > 0)
                customer.Weight = new Weight(model.Weight);
            customer.Race = (Race)System.Enum.Parse(typeof(Race), model.Race, true);
            customer.Copay = model.Copay;
            customer.MedicareAdvantagePlanName = model.MedicareAdvantagePlanName;

            return customer;
        }

        public Customer CreateCustomer(OnSiteRegistrationEditModel model, OrganizationRoleUser createdByOrgRoleUser)
        {
            var customer = new Customer
                               {
                                   Name = new Name
                                              {
                                                  FirstName = model.FirstName,
                                                  LastName = model.LastName
                                              },
                                   HomePhoneNumber = model.HomeNumber
                               };
            if (!string.IsNullOrEmpty(model.Email))
            {
                string[] emailSplitUp = model.Email.Split(new[] { '@' });
                customer.Email = new Email { Address = emailSplitUp[0], DomainName = emailSplitUp[1] };
            }
            customer.Address = Mapper.Map<AddressEditModel, Address>(model.Address);
            customer.UserLogin = new UserLogin
            {
                UserName = GenerateUniqueUserName(model.FirstName + "." + model.LastName),
                Password = GenerateUniquePassword(),
                IsSecurityQuestionVerified = false,
                UserVerified = false
            };

            customer.Gender = (Gender)model.Gender;

            if (model.DateofBirth.HasValue)
                customer.DateOfBirth = model.DateofBirth;

            customer.AddedByRoleId = createdByOrgRoleUser.RoleId;
            customer.EmployeeId = model.EmployeeId;
            customer.InsuranceId = model.InsuranceId;

            var height = new Height(model.HeightInFeet, model.HeightInInch);
            customer.Height = height.TotalInches > 0 ? height : null;

            if (model.Weight > 0)
                customer.Weight = new Weight(model.Weight);
            customer.Race = (Race)System.Enum.Parse(typeof(Race), model.Race, true);

            return customer;
        }

        private int count = 0;
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

        public Customer CreateCustomer(CorporateCustomerEditModel model, string tag, OrganizationRoleUser createdByOrgRoleUser, Customer customer, Language language, Lab lab, long activityTypeId, long? source)
        {
            if (customer == null)
                customer = new Customer
                {
                    Address = new Address()
                };

            customer.InsuranceId = model.MemberId;
            customer.Name = new Name
                                {
                                    FirstName = model.FirstName,
                                    MiddleName = model.MiddleName,
                                    LastName = model.LastName
                                };
            if (!string.IsNullOrEmpty(model.Gender))
                customer.Gender = (Gender)System.Enum.Parse(typeof(Gender), model.Gender, true);

            if (!string.IsNullOrEmpty(model.Dob))
            {
                customer.DateOfBirth = Convert.ToDateTime(model.Dob);
            }

            if (customer.CustomerId <= 0)
            {
                if (!string.IsNullOrEmpty(model.Email) || !string.IsNullOrEmpty(model.AlternateEmail))
                    customer.EnableEmail = true;
            }
            else if (string.IsNullOrEmpty(customer.Email.ToString()) && string.IsNullOrEmpty(customer.AlternateEmail.ToString()))
            {
                if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.AlternateEmail))
                    customer.EnableEmail = false;
                else
                    customer.EnableEmail = true;
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                //string[] emailSplitUp = model.Email.Split(new[] { '@' });
                customer.Email = new Email(model.Email); //{ Address = emailSplitUp[0], DomainName = emailSplitUp[1] };
            }
            if (!string.IsNullOrEmpty(model.AlternateEmail))
            {
                //string[] emailSplitUp = model.AlternateEmail.Split(new[] { '@' });
                customer.AlternateEmail = new Email(model.AlternateEmail);// { Address = emailSplitUp[0], DomainName = emailSplitUp[1] };
            }

            string mobilePhoneNumber = PhoneNumber.Create(PhoneNumber.ToNumber(model.PhoneCell), PhoneNumberType.Mobile).ToString();
            string homePhoneNumber = PhoneNumber.Create(PhoneNumber.ToNumber(model.PhoneHome), PhoneNumberType.Home).ToString();

            if ((customer.MobilePhoneNumber != null && PhoneNumber.Create(PhoneNumber.ToNumber(customer.MobilePhoneNumber.ToString()), PhoneNumberType.Mobile).ToString() != mobilePhoneNumber) ||
                (customer.HomePhoneNumber != null && PhoneNumber.Create(PhoneNumber.ToNumber(customer.HomePhoneNumber.ToString()), PhoneNumberType.Home).ToString() != homePhoneNumber))
            {
                customer.IsIncorrectPhoneNumber = false;
                customer.IncorrectPhoneNumberMarkedDate = null;
            }

            if (!string.IsNullOrEmpty(model.PhoneCell))
                customer.MobilePhoneNumber = PhoneNumber.Create(PhoneNumber.ToNumber(model.PhoneCell), PhoneNumberType.Mobile);

            if (!string.IsNullOrEmpty(model.PhoneHome))
                customer.HomePhoneNumber = PhoneNumber.Create(PhoneNumber.ToNumber(model.PhoneHome), PhoneNumberType.Mobile);

            customer.Address.CountryId = (long)CountryCode.UnitedStatesAndCanada;
            customer.Address.StreetAddressLine1 = model.Address1;
            customer.Address.StreetAddressLine2 = model.Address2;
            customer.Address.City = model.City;
            customer.Address.CityId = 0;
            customer.Address.State = model.State;
            customer.Address.StateId = 0;
            customer.Address.ZipCode = new ZipCode(model.Zip);

            if (!string.IsNullOrEmpty(model.Hicn))
            {
                customer.Hicn = model.Hicn;
            }

            if (!string.IsNullOrEmpty(model.Mbi))
            {
                customer.Mbi = model.Mbi;
            }

            customer.Tag = tag;

            if (!((source.HasValue && source.Value == (long)MemberUploadSource.Aces) && customer.ActivityTypeIsManual))
            {
                customer.ActivityId = activityTypeId;
                customer.ActivityTypeIsManual = true;
            }


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

            //if (model.IsEligible.ToLower() == "yes")
            //    customer.IsEligible = true;
            //else if (model.IsEligible.ToLower() == "no")
            //    customer.IsEligible = false;
            //else
            //    customer.IsEligible = null;

            if (!string.IsNullOrEmpty(model.Language))
            {
                if (language != null)
                    customer.LanguageId = language.Id;
            }

            if (!string.IsNullOrEmpty(model.Lab))
            {
                if (lab != null)
                    customer.LabId = lab.Id;
            }

            customer.AddedByRoleId = createdByOrgRoleUser.RoleId;
            customer.Copay = model.Copay;
            customer.MedicareAdvantagePlanName = model.MedicareAdvantagePlanName;

            customer.Lpi = model.Lpi;
            customer.Market = model.Market;
            customer.Mrn = model.Mrn;
            customer.GroupName = model.GroupName;

            customer.AdditionalField1 = model.AdditionalField1;
            customer.AdditionalField2 = model.AdditionalField2;
            customer.AdditionalField3 = model.AdditionalField3;
            customer.AdditionalField4 = model.AdditionalField4;

            if (!(source.HasValue && source.Value == (long)MemberUploadSource.Aces))
            {
                if ((customer.CustomerId <= 0 || customer.BillingMemberPlanYear == model.BillingMemberPlanYear ||
                    (!string.IsNullOrEmpty(model.BillingMemberId) || !string.IsNullOrEmpty(model.BillingMemberPlan))))
                {
                    customer.BillingMemberId = model.BillingMemberId;
                    customer.BillingMemberPlan = model.BillingMemberPlan;
                    customer.BillingMemberPlanYear = model.BillingMemberPlanYear;
                }
            }

            if (!string.IsNullOrWhiteSpace(model.AcesId))
                customer.AcesId = model.AcesId;

            //if (model.MemberUploadSourceId.HasValue && model.MemberUploadSourceId == (long)MemberUploadSource.Aces)
            customer.MemberUploadSourceId = model.MemberUploadSourceId;

            if (source.HasValue && source.Value == (long)MemberUploadSource.Aces)
            {
                if (model.DNCFlag.ToLower() == "yes")
                {
                    customer.DoNotContactUpdateSource = (long)DoNotContactSource.CIM;
                    customer.DoNotContactUpdateDate = DateTime.Now;
                    customer.DoNotContactTypeId = (long)DoNotContactType.DoNotContact;
                }
                else if (model.DNCFlag.ToLower() == "no")
                {
                    customer.DoNotContactUpdateSource = (long?)null;
                    customer.DoNotContactUpdateDate = (DateTime?)null;
                    customer.DoNotContactTypeId = (long?)null;
                    customer.DoNotContactReasonId = (long?)null;
                }

                var productTypePairs = ProductType.CHA.GetNameValuePairs();
                customer.ProductTypeId = productTypePairs.First(x => x.SecondValue.ToLower() == model.Product.ToLower()).FirstValue;

                customer.AcesClientId = model.ACESClientID;
            }

            return customer;
        }

        public Address CreateAddress(CorporateCustomerEditModel model, string addresstoCreate)
        {
            var address = new Address();
            address.CountryId = (long)CountryCode.UnitedStatesAndCanada;
            address.CityId = 0;
            address.StateId = 0;
            if (addresstoCreate.ToLower() == MemberUploadAddress.CustomerAddress.ToString().ToLower())
            {
                address.StreetAddressLine1 = model.Address1;
                address.StreetAddressLine2 = model.Address2;
                address.City = model.City;
                address.State = model.State;
                address.ZipCode = model.Zip.Length >= 5 ? new ZipCode(model.Zip.Substring(0, 5)) : new ZipCode(model.Zip.PadLeft(5, '0'));
            }
            else if (addresstoCreate.ToLower() == MemberUploadAddress.PcpAddress.ToString().ToLower())
            {
                address.StreetAddressLine1 = model.PcpAddress1;
                address.StreetAddressLine2 = model.PcpAddress2;
                address.City = model.PcpCity;
                address.State = model.PcpState;
                address.ZipCode = model.PcpZip.Length >= 5 ? new ZipCode(model.PcpZip.Substring(0, 5)) : new ZipCode(model.PcpZip.PadLeft(5, '0'));
            }
            else if (addresstoCreate.ToLower() == MemberUploadAddress.PcpMailingAddress.ToString().ToLower())
            {
                address.StreetAddressLine1 = model.PCPMailingAddress1;
                address.StreetAddressLine2 = model.PCPMailingAddress2;
                address.City = model.PCPMailingCity;
                address.State = model.PCPMailingState;
                address.ZipCode = model.PCPMailingZip.Length >= 5 ? new ZipCode(model.PCPMailingZip.Substring(0, 5)) : new ZipCode(model.PCPMailingZip.PadLeft(5, '0'));
            }
            return address;
        }
    }
}
