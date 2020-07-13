using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Operations.Factories
{
    [DefaultImplementation]
    public class BloodworksLabelViewModelFactory : IBloodworksLabelViewModelFactory
    {
        public IEnumerable<BloodworksLabelViewModel> Create(IEnumerable<Customer> customers, Event eventData)
        {
            var listModel = new List<BloodworksLabelViewModel>();

            foreach (var customer in customers)
            {
                var model = new BloodworksLabelViewModel()
                                {
                                    TestDate = eventData.EventDate,
                                    CustomerId = customer.CustomerId,
                                    CustomerName = customer.Name,
                                    CustomerAddress = customer.Address,
                                    PhoneNumber = customer.HomePhoneNumber,
                                    DateOfBirth = customer.DateOfBirth,
                                    Gender = customer.Gender
                                };

                if (customer.DateOfBirth.HasValue)
                {
                    var now = DateTime.Now;
                    var birth = customer.DateOfBirth.Value;
                    var years = now.Year - birth.Year - ((now.DayOfYear < birth.DayOfYear) ? 1 : 0);
                    model.Age = years;
                }
                listModel.Add(model);
            }
            return listModel;
        }

        public BloodworksLabelViewModel Create(Customer customer, Event eventData, IEnumerable<Test> tests)
        {
            var model = new BloodworksLabelViewModel
            {
                TestDate = eventData.EventDate,
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name,
                CustomerAddress = customer.Address,
                PhoneNumber = customer.HomePhoneNumber ?? customer.MobilePhoneNumber ?? customer.OfficePhoneNumber,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                EventId = eventData.Id
            };

            if (tests != null && tests.Any())
            {
                model.BloodTests = string.Join(", ", tests.Select(t => t.Alias).ToArray());
                model.BloodTestIds = tests.Select(t => t.Id);
            }

            if (customer.DateOfBirth.HasValue)
            {
                var now = DateTime.Now;
                var birth = customer.DateOfBirth.Value;
                var years = now.Year - birth.Year - ((now.DayOfYear < birth.DayOfYear) ? 1 : 0);
                model.Age = years;
            }
            return model;
        }
    }
}
