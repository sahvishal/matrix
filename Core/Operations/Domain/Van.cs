using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class Van : DomainObjectBase
    {
        public Van()
        { }
        
        public Van(long vanId)
            : base(vanId)
        { }

        public string Name { get; set; }
        public long StateId { get; set; }        
        public string Make{get;set;}
        public string VehicleIdentificationNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string Description { get; set; }    
        public bool IsActive { get; set; }
    }
}
