using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class CustomerScreeningViewData
    {        
        public Customer Customer { get; set; }

        // Event Part
        public long EventId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string HostName { get; set; }
        public Address ScreeningLocation { get; set; }
        
        // Order Part
        public string ScreeningPackage { get; set; }
        public decimal ScreeningAmount { get; set; }
        public List<PaymentInstrument> PaymentData { get; set; } // TODO: We need to create Payment Transactions, which can have Payment Instrument.

        public IEnumerable<ChargeCard> ChargeCards { get; set; }
        public IEnumerable<Check> Checks { get; set; }
        
        // Content part for the Readings.
        public List<TestResult> ScreeningResult { get; set; }
        public IEnumerable<Test> TestsPurchased { get; set; }

        // Need to create a MV D.O.
        public IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> Physicians { get; set; }
        public BasicBiometric BasicBiometric { get; set; }

        public IEnumerable<EventPhysicianTest> EventPhysicianTests { get; set; } 

        // Also Need per Test conduction Technician Info. Might need to create a metadata sort of DO for Test Results.
    }

    public class CustomerScreeningEvaluatinPhysicianViewModel
    {
        public long PhysicianId { get; set; }
        public string PhysicianName { get; set; }
        public string PhysicianSpecialization { get; set; }
        public string PhysicianOrganization { get; set; }
        public string PhysicianSignatureFilePath { get; set; }

    }
}
