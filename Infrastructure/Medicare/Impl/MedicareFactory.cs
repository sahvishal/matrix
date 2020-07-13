using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class MedicareFactory : IMedicareFactory
    {
        private readonly ILanguageRepository _languageRepository;

        public MedicareFactory(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public MedicareCustomerViewModel CreateCustomerViewModel(Customer domain)
        {
            var rmodel = new MedicareCustomerViewModel()
            {
                Id = domain.CustomerId,
                FirstName = domain.Name.FirstName,
                LastName = domain.Name.LastName,
                MiddleName = domain.Name.MiddleName,
                Email = domain.Email != null ? domain.Email.ToString() : "",
                PhoneNumber = PhoneNumber.ToNumber(domain.HomePhoneNumber.ToString()),
                StreetAddressLine1 = domain.Address != null ? domain.Address.StreetAddressLine1 : "",
                StreetAddressLine2 = domain.Address != null ? domain.Address.StreetAddressLine2 : "",
                City = domain.Address != null ? domain.Address.City : "",
                StateCode = domain.Address != null ? domain.Address.StateCode : "",
                Zip = domain.Address != null ? domain.Address.ZipCode.Zip : "",
                DateOfBirth = domain.DateOfBirth,
                Gender = domain.Gender.ToString(),
                Hicn = domain.Hicn,
                InsuranceId = domain.InsuranceId,
                MedicareAdvantageNumber = domain.MedicareAdvantageNumber,
                // PreferredLanguage = domain.PreferredLanguage,
                Race = domain.Race.ToString(),
                Tag = domain.Tag,
                Height = domain.Height != null ? domain.Height.TotalInches.ToString() : null,
                Weight = domain.Weight != null ? domain.Weight.Pounds.ToString() : null,
                Mrn = domain.Mrn
            };

            if (domain.LanguageId.HasValue)
            {

                var language = _languageRepository.GetById(domain.LanguageId.Value);
                if (language != null)
                    rmodel.PreferredLanguage = language.Name;
            }
            return rmodel;
        }

        public void UpdateCustomer(MedicareCustomerViewModel model, Customer domain)
        {
            domain.CustomerId = model.Id;
            domain.Name.FirstName = model.FirstName;
            domain.Name.LastName = model.LastName;
            domain.Name.MiddleName = model.MiddleName;
            domain.Email = string.IsNullOrEmpty(model.Email) ? domain.Email : new Email(model.Email);
            domain.HomePhoneNumber = PhoneNumber.Create(model.PhoneNumber, PhoneNumberType.Home);

            domain.DateOfBirth = model.DateOfBirth;
            if (!string.IsNullOrEmpty(model.Gender) && (model.Gender != "Unknown"))
                domain.Gender = (Gender)Enum.Parse(typeof(Gender), model.Gender, true);
            else if (!string.IsNullOrEmpty(model.Gender) && (model.Gender == "Unknown"))
            {
                domain.Gender = Gender.Unspecified;
            }

            domain.Hicn = model.Hicn;
            domain.InsuranceId = model.InsuranceId;
            domain.MedicareAdvantageNumber = model.MedicareAdvantageNumber;
            //
            domain.PreferredLanguage = model.PreferredLanguage;
            if (string.IsNullOrEmpty(model.PreferredLanguage))
            {
                var language = _languageRepository.GetByName(model.PreferredLanguage);
                if (language != null)
                    domain.LanguageId = language.Id;
            }
            //
            if (!string.IsNullOrEmpty(model.Race))
                domain.Race = (Race)Enum.Parse(typeof(Race), model.Race, true);

            if (!string.IsNullOrEmpty(model.Height))
            {
                double d;
                double.TryParse(model.Height, out d);
                var feet = (int)(d / 12);
                var inch = (int)(d % 12);
                domain.Height = new Height(feet, inch);
            }

            if (!string.IsNullOrEmpty(model.Weight))
            {
                double d;
                double.TryParse(model.Weight, out d);
                domain.Weight = new Weight(d);
            }

        }

        public IEnumerable<MedicareEventCustomerAcesViewModel> GetMedicareEventCustomerAcesViewModelList(IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Customer> customers)
        {
            return (from eventCustomerResult in eventCustomerResults
                    let customer = customers.First(x => x.CustomerId == eventCustomerResult.CustomerId)
                    select new MedicareEventCustomerAcesViewModel()
                    {
                        EventId = eventCustomerResult.EventId,
                        CustomerId = customer.CustomerId,
                        AcesId = customer.AcesId,
                        MemberId = customer.InsuranceId
                    }).ToArray();
        }
    }
}
