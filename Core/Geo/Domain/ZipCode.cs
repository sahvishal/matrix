using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Geo.Domain
{
    public class ZipCode : DomainObjectBase
    {
        public string Zip { get; set; }
        // TODO: The type for Latitude and Longitude are converted to float since there was a problem with a zipcode:74804.
        // Now its working fine for all the zipcodes.
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        [IgnoreAudit]
        public TimeZone TimeZone { get; set; }
        public bool IsInDaylightSavingsTime { get; set; }
        public long CityId { get; set; }

        public ZipCode(string zipCode)
        {
            Zip = zipCode;
        }

        public ZipCode()
        {}

        public ZipCode(long zipId)
            : base(zipId)
        {}

        // TODO: Move to DomainObjectBase?
        public override bool Equals(object zipCodeObject)
        {
            var zipCodeToCompare = zipCodeObject as ZipCode;
            if (zipCodeToCompare == null)
            {
                return false;
            }
            return Id == zipCodeToCompare.Id;
        }

        public override string ToString()
        {
            return Zip;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}