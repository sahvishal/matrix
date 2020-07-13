using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class MedicalVendorEarningCustomerAggregate
    {
        public long CustomerId { get; set; }
        public long MedicalVendorId { get; set; }
        public long OrganizationRoleUserId { get; set; }
        
        public DateTime EvaluationDate { get; set; }
        public decimal AmountEarned { get; set; }
        
        public Name CustomerName { get; set; }
        public Name PhysicianName { get; set; }
        public string PackageName { get; set; }
    }
}