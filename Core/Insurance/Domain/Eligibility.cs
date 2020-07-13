using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Insurance.Domain
{
    public class Eligibility : DomainObjectBase
    {
        public string Guid { get; set; }
        public long InsuranceCompanyId { get; set; }
        public string PlanName { get; set; }
        public string GroupName { get; set; }
        public decimal CoPayment { get; set; }
        public decimal CoInsurance { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime DateCreated { get; set; }
        public long? CreatedByOrgRoleUserId { get; set; }
    }
}
