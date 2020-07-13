namespace Falcon.App.Core.CallQueues.Enum
{
    public enum QueueCriteria
    {
        AllProspects = 1,
        AllCustomers = 2,
        AllCustomersOlderThanOneYear = 3,
        NoShow = 4,
        Cancellation = 5,
        OnlineSignup = 6,
        CallCenterSignup = 7,
        NotServicedZip = 8,
        PricingConcerns = 9,
        InsuranceConcerns = 10,
        MorningAppointmentPreferred = 11,
        AfternoonAppointmentPreferred = 12,
        PhysicianPartner = 13
    }
}