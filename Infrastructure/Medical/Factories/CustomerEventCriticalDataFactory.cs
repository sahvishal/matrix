using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class CustomerEventCriticalDataFactory : ICustomerEventCriticalDataFactory
    {
        public CustomerEventCriticalDataListModel Create(IEnumerable<EventCustomerResult> eventCustomerResults, IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<OrderedPair<long, string>> ecAndPackagePair,
            IEnumerable<OrderedPair<long, string>> ecAndTestPair, IEnumerable<CustomerCriticalData> customersCriticalData, IEnumerable<PrimaryCarePhysician> primaryCarePhysicians, IEnumerable<AssignedPhysicianViewModel> assignedPhysicians,
            IEnumerable<CustomerResultStatusViewModel> customerResults, IEnumerable<Test> tests, IEnumerable<OrderedPair<long, long>> eventCustomerResultIdNotesIdPairs, IEnumerable<Notes> notes, IEnumerable<OrderedPair<long, string>> idNamePairs,
            IEnumerable<Pod> pods, IEnumerable<OrderedPair<long, string>> eventIdHospitalPartnerNamePairs)
        {
            var listModel = new CustomerEventCriticalDataListModel();
            var collection = new List<CustomerEventCriticalDataViewModel>();
            foreach (var eventCustomerResult in eventCustomerResults)
            {
                var theEvent = events.Where(e => e.Id == eventCustomerResult.EventId).Single();
                var customer = customers.Where(c => c.CustomerId == eventCustomerResult.CustomerId).Single();

                var podNames = string.Join(", ", pods.Where(p => theEvent.PodIds.Contains(p.Id)).Select(p => p.Name));

                var packagename = ecAndPackagePair.Where(p => p.FirstValue == eventCustomerResult.Id).Select(p => p.SecondValue).SingleOrDefault();
                var testsName = string.Join(", ", ecAndTestPair.Where(p => p.FirstValue == eventCustomerResult.Id).Select(p => p.SecondValue).ToArray());

                if (string.IsNullOrEmpty(packagename)) packagename = testsName;
                else if (!string.IsNullOrEmpty(testsName)) packagename += " + " + testsName;

                var criticalData =
                    customersCriticalData.Where(
                        ccd =>
                        ccd.CustomerId == eventCustomerResult.CustomerId && ccd.EventId == eventCustomerResult.EventId)
                        .Select(ccd => ccd).ToList();

                var primaryCarePhysician = primaryCarePhysicians.Where(pcp => pcp.CustomerId == eventCustomerResult.CustomerId).Select(pcp => pcp).SingleOrDefault();

                var assignedPhysician =
                    assignedPhysicians.Where(ap => ap.EventCustomerId == eventCustomerResult.Id).Select(ap => ap).
                        SingleOrDefault();

                IEnumerable<Notes> customerNotes = null;
                var eventCustomerResultIdNotesIdPair = eventCustomerResultIdNotesIdPairs.Where(ecrn => ecrn.FirstValue == eventCustomerResult.Id).Select(ecrn => ecrn.SecondValue).ToArray();
                if (eventCustomerResultIdNotesIdPair.Count() > 0)
                {
                    customerNotes = notes.Where(n => eventCustomerResultIdNotesIdPair.Contains(n.Id)).Select(n => n);
                }

                var hospitalPartnerName = eventIdHospitalPartnerNamePairs.Where(ehp => ehp.FirstValue == theEvent.Id).Select(ehp => ehp.SecondValue).SingleOrDefault();

                var viewModel = new CustomerEventCriticalDataViewModel
                                    {
                                        EventCustomerResultId = eventCustomerResult.Id,
                                        CustomerId = customer.CustomerId,
                                        CustomerName = customer.NameAsString,
                                        Address = Mapper.Map<Address, AddressViewModel>(customer.Address),
                                        Email = customer.Email != null ? customer.Email.ToString() : "",
                                        Phone = criticalData.Count > 0 ? criticalData.First().ContactNumber.ToString() : customer.HomePhoneNumber.ToString(),
                                        CustomerOrder = packagename,
                                        EventId = theEvent.Id,
                                        EventName = theEvent.Name,
                                        EventDate = theEvent.EventDate,
                                        Pod = podNames,
                                        HospitalSponsor = !string.IsNullOrEmpty(hospitalPartnerName) ? hospitalPartnerName : "N/A",
                                        PrimaryCarePhysician =
                                            primaryCarePhysician != null ? primaryCarePhysician.Name.ToString() : "",
                                        PrimaryPhysician = assignedPhysician != null && assignedPhysician.Primary != null ? assignedPhysician.Primary.Name : "",
                                        OverReadPhysician = assignedPhysician != null && assignedPhysician.Overread != null ? assignedPhysician.Overread.Name : "",
                                        Notes = customerNotes
                                    };
                var criticalTestDataViewModels = new List<CustomerEventCriticalTestDataViewModel>();

                var customerResult = customerResults.Where(tr => tr.EventCustomerId == eventCustomerResult.Id).FirstOrDefault();

                var testResults = customerResult.TestResults.Where(tr => tr.IsCritical || tr.CriticalMarkedByPhysician);
                var result = "Urgent";
                foreach (var testResultStatusViewModel in testResults)
                {
                    var customerCriticalData = criticalData.Where(cd => cd.TestId == testResultStatusViewModel.TestId).Select(cd => cd).FirstOrDefault();
                    var testModel = new CustomerEventCriticalTestDataViewModel
                                        {
                                            DateOfSubmission = customerCriticalData != null ? customerCriticalData.DateofSubmission : (DateTime?)null,
                                            ContactNumber = customerCriticalData != null ? customerCriticalData.ContactNumber : customer.HomePhoneNumber,
                                            TechnicianName = customerCriticalData != null ? idNamePairs.Where(inp => inp.FirstValue == customerCriticalData.TechnicianId).Select(inp => inp.SecondValue).SingleOrDefault() : "",
                                            ValidatingTechnicianName = customerCriticalData != null ? idNamePairs.Where(inp => inp.FirstValue == customerCriticalData.ValidatingTechnicianId).Select(inp => inp.SecondValue).SingleOrDefault() : "",
                                            PrimaryPhysicianName = customerCriticalData != null ? customerCriticalData.Physician : "",
                                            TestName = tests.Where(t => t.Id == testResultStatusViewModel.TestId).Select(t => t.Name).Single(),
                                            TechnicianNotes = customerCriticalData != null && !string.IsNullOrEmpty(customerCriticalData.TechnicianNotes) ? customerCriticalData.TechnicianNotes : "N/A",
                                            TechnicianNotesForPhysician =
                                                customerCriticalData != null && !string.IsNullOrEmpty(customerCriticalData.TechnicianNotesforPhysician) ? customerCriticalData.TechnicianNotesforPhysician : "N/A",
                                            TestId = testResultStatusViewModel.TestId,
                                            IsCritical = testResultStatusViewModel.IsCritical,
                                            IsUrgent = testResultStatusViewModel.CriticalMarkedByPhysician
                                        };
                    if (testModel.IsCritical)
                        result = "Critical";
                    if (!testModel.IsCritical && testModel.IsUrgent)
                    {
                        testModel.PrimaryPhysicianName = testResultStatusViewModel.EvaluatedBy;
                        testModel.TechnicianNotesForPhysician = testResultStatusViewModel.PhysicianRemarks;
                    }
                    criticalTestDataViewModels.Add(testModel);
                }

                viewModel.Tests = criticalTestDataViewModels;
                viewModel.Result = result;
                collection.Add(viewModel);
            }
            listModel.Collection = collection;
            return listModel;
        }
    }
}
