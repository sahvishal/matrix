using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class PatientWorksheet
    {
        public long CustomerId { get; set; }
        public Name Name { get; set; }
        public DateTime? Dob { get; set; }
        public Height Height { get; set; }
        public Weight Weight { get; set; }
        public EventPackage Package { get; set; }
        public IEnumerable<EventTest> Tests { get; set; }
        public Gender Gender { get; set; }
        public string Lab { get; set; }

        public IEnumerable<EventTest> AlaCarteTest { get; set; }
        public IEnumerable<ElectronicProduct> AllProducts { get; set; }

        public IEnumerable<string> IcdCodes { get; set; }

        public IEnumerable<string> PreApporvedTestNames { get; set; }

        public long ProductId { get; set; }

        public bool PrintScreeningInfo { get; set; }
        public bool PrintPatientWorkSheet { get; set; }

        public DateTime EventDate { get; set; }

        public bool IsCorporateEvent { get; set; }

        public IEnumerable<string> CustomTags { get; set; }
    }
}
