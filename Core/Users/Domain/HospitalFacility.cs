namespace Falcon.App.Core.Users.Domain
{
    public class HospitalFacility : Organization
    {
        public long ContractId { get; set; }
        public long? ResultLetterFileId { get; set; }
        public string CannedMessage { get; set; }
        public long HospitalPartnerId { get; set; }
        
        public HospitalFacility()
        {}

        public HospitalFacility(Organization organization)
            :base(organization)
        {}

        public HospitalFacility(long hospitalFacilityId)
            : base(hospitalFacilityId)
        {}
    }
}
