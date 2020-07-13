namespace Falcon.App.Core.Sales.ViewModels
{
    public class HospitalPartnerScheduledOutcomeViewModel
    {
        public long ScheduledOutcome { get; set; }
        public long ScheduledWithAffiliatedPcpOutcome { get; set; }
        public long ScheduledWithAffiliatedSpecialistOutcome { get; set; }
        public long ReferredToAffiliatedPcpOutcome { get; set; }
        public long ReferredToAffiliatedSpecialistOutcome { get; set; }
        public long SelfScheduledWithNonAffiliatedPhysicianOutcome { get; set; }
        public long SelfScheduledWithAffiliatedPhysicianOutcome { get; set; }
        public long ScheduledWithEmployedPhysician { get; set; }
        public long ReferredToEmployedPhysician { get; set; }
        public long SelfScheduledWithEmployedPhysician { get; set; }
        public long Uninsured { get; set; }
        public long TotalCount { get; set; }
    }
}
