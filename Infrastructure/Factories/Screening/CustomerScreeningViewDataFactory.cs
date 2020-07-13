using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Medical.Interfaces;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Factories.Screening
{
    [DefaultImplementation(Interface = typeof(ICustomerScreeningViewDataFactory))]
    public class CustomerScreeningViewDataFactory : ICustomerScreeningViewDataFactory
    {
        public CustomerScreeningViewData Create(List<TestResult> testResults, Customer customer, Core.Scheduling.Domain.Appointment appointment, Core.Scheduling.Domain.Event theEvent, Package package, IEnumerable<Test> tests, Host host,
            Physician primaryPhysician, Physician overreadPhysician, Core.Finance.Domain.Order order, BasicBiometric basicBiometric)
        {
            var viewData = new CustomerScreeningViewData
            {
                ScreeningResult = testResults,
                ScreeningLocation = host.Address,
                HostName = theEvent.Name,
                EventDate = theEvent.EventDate,
                Customer = customer
            };

            var physicians = new List<CustomerScreeningEvaluatinPhysicianViewModel>();

            physicians.Add(new CustomerScreeningEvaluatinPhysicianViewModel
                               {
                                   PhysicianId = primaryPhysician.PhysicianId,
                                   PhysicianName = string.IsNullOrEmpty(primaryPhysician.DisplayName) ? primaryPhysician.NameAsString : primaryPhysician.DisplayName,
                                   PhysicianSignatureFilePath = primaryPhysician.SignatureFile != null ? primaryPhysician.SignatureFile.Path : string.Empty
                               });

            if (overreadPhysician != null)
            {
                physicians.Add(new CustomerScreeningEvaluatinPhysicianViewModel
                {
                    PhysicianId = overreadPhysician.PhysicianId,
                    PhysicianName = string.IsNullOrEmpty(overreadPhysician.DisplayName) ? overreadPhysician.NameAsString : overreadPhysician.DisplayName,
                    PhysicianSignatureFilePath = overreadPhysician.SignatureFile != null ? overreadPhysician.SignatureFile.Path : string.Empty
                });
            }

            viewData.Physicians = physicians;

            string screeenedFor = "";
            var testPurchased = new List<Test>();
            if (package != null)
            {
                screeenedFor = package.Name;
                testPurchased.AddRange(package.Tests);
            }

            if (tests != null && tests.Count() > 0)
            {
                if (!string.IsNullOrEmpty(screeenedFor)) screeenedFor += ", ";

                screeenedFor += string.Join(", ", tests.Select(t => t.Name));
                testPurchased.AddRange(tests);
            }

            viewData.TestsPurchased = testPurchased;

            viewData.PaymentData = order.PaymentsApplied;
            viewData.ScreeningAmount = order.TotalAmountPaid;
            viewData.ScreeningPackage = screeenedFor;
            viewData.AppointmentTime = appointment.StartTime;
            viewData.EventId = theEvent.Id;
            viewData.BasicBiometric = basicBiometric;

            return viewData;
        }
    }
}
