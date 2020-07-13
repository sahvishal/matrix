using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class CustomerEventCriticalTestDataFactory : ICustomerEventCriticalTestDataFactory
    {
        public CustomerEventCriticalTestDataEditModel Create(long eventId, long testId, Customer customer, CustomerCriticalData criticalData, EventCustomer eventCustomer, IEnumerable<OrderedPair<long, string>> physicians, PrimaryCarePhysician pcp,
            EventCustomerResult eventCustomerResult)
        {
            var model = new CustomerEventCriticalTestDataEditModel
                            {
                                CustomerName = customer.NameAsString,
                                ContactNumber = (customer.HomePhoneNumber ?? customer.OfficePhoneNumber) ?? customer.MobilePhoneNumber,
                                EventId = eventId,
                                TestId = testId,
                                CustomerId = customer.CustomerId,
                                DateOfBirth = customer.DateOfBirth,
                                EventCustomerId = eventCustomer.Id,
                                Gender = customer.Gender,
                                DateOfSubmission = DateTime.Now,
                                PrimaryPhysician = physicians != null && physicians.Any() ? physicians.ElementAt(0).SecondValue : "",
                                PrimaryCarePhysicianName = pcp != null ? pcp.Name.ToString() : "",
                                PrimaryCarePhysicianPhoneNumber = pcp != null ? pcp.Primary : null,
                                ResultState = eventCustomerResult != null ? eventCustomerResult.ResultState : 1
                            };

            if (criticalData != null)
            {
                model.CustomerEventScreeningTestId = criticalData.Id;
                model.DateOfSubmission = criticalData.DateofSubmission;
                model.IsCustomerSigned = criticalData.IsCustomerSigned;
                model.IsTechnicianSigned = criticalData.IsTechnicianSigned;
                model.TechnicianNotes = criticalData.TechnicianNotes;
                model.TechnicianNotesForPhysician = criticalData.TechnicianNotesforPhysician;
                model.ContactNumber = criticalData.ContactNumber ?? model.ContactNumber;
                model.TechnicianId = criticalData.TechnicianId;
                model.ValidatingTechnicianId = criticalData.ValidatingTechnicianId;
                model.PrimaryPhysician = criticalData.Physician;
                model.HasPcp = !string.IsNullOrEmpty(model.PrimaryCarePhysicianName) ? true : criticalData.HasPcp;
                model.IsDefaultFollowup = criticalData.IsDefaultFollowup;
                model.IsPatientReceivedImages = criticalData.IsPatientReceivedImages;
                model.Symptoms = criticalData.Symptoms;
            }
            else
            {
                model.HasPcp = !string.IsNullOrEmpty(model.PrimaryCarePhysicianName) ? true : false;
                model.IsDefaultFollowup = true;
            }

            return model;
        }

        public CustomerCriticalData Create(CustomerEventCriticalTestDataEditModel model)
        {
            var criticalData = new CustomerCriticalData
                                   {
                                       Id = model.CustomerEventScreeningTestId,
                                       DateofSubmission = model.DateOfSubmission,
                                       ContactNumber = model.ContactNumber,
                                       CustomerId = model.CustomerId,
                                       EventId = model.EventId,
                                       IsCustomerSigned = model.IsCustomerSigned,
                                       IsTechnicianSigned = model.IsTechnicianSigned,
                                       TechnicianNotes = model.TechnicianNotes,
                                       TechnicianNotesforPhysician = model.TechnicianNotesForPhysician,
                                       TestId = model.TestId,
                                       TechnicianId = model.TechnicianId,
                                       ValidatingTechnicianId = model.ValidatingTechnicianId,
                                       Physician = model.PrimaryPhysician,
                                       HasPcp = model.HasPcp,
                                       IsDefaultFollowup = model.IsDefaultFollowup,
                                       IsPatientReceivedImages = model.IsPatientReceivedImages,
                                       Symptoms = model.Symptoms
                                   };

            return criticalData;
        }

        public CustomerEventCriticalTestDataViewModel Create(CustomerCriticalData criticalData, Customer customer, PrimaryCarePhysician pcp, IEnumerable<OrderedPair<long, string>> idNamePairs, string testName)
        {
            var model = new CustomerEventCriticalTestDataViewModel
                            {
                                DateOfSubmission = criticalData.DateofSubmission,
                                CustomerName = customer.NameAsString,
                                ContactNumber = criticalData.ContactNumber,
                                PrimaryCarePhysician = pcp != null ? pcp.Name.ToString() : "",
                                TestName = testName,
                                TechnicianNotes = criticalData.TechnicianNotes,
                                TechnicianNotesForPhysician = criticalData.TechnicianNotesforPhysician,
                                TechnicianName = idNamePairs.Where(inp => inp.FirstValue == criticalData.TechnicianId).Select(inp => inp.SecondValue).SingleOrDefault(),
                                ValidatingTechnicianName = idNamePairs.Where(inp => inp.FirstValue == criticalData.ValidatingTechnicianId).Select(inp => inp.SecondValue).SingleOrDefault(),
                                PrimaryPhysicianName = criticalData.Physician,
                                HasPcp = (pcp != null && !string.IsNullOrEmpty(pcp.Name.ToString())) ? true : criticalData.HasPcp,
                                IsDefaultFollowup = criticalData.IsDefaultFollowup,
                                IsPatientReceivedImages = criticalData.IsPatientReceivedImages,
                                Symptoms = criticalData.Symptoms
                            };

            return model;
        }
    }
}