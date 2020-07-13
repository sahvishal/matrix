using System.Text;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Geo.Domain
{
    public class Address : DomainObjectBase
    {
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public long CityId { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public long StateId { get; set; }
        public string Country { get; set; }
        public long CountryId { get; set; }
        public long? VerificationOrgRoleUserId { get; set; }
        public ZipCode ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [IgnoreAudit]
        public bool? LatLogUseForAddressMaping { get; set; }

        public Address()
        {}

        public Address(long addressId)
            : base(addressId)
        {}

        public Address(string streetAddressLine1, string streetAddressLine2, string cityName, string stateName, string zipCode, string countryName)
        {
            StreetAddressLine1 = streetAddressLine1;
            StreetAddressLine2 = streetAddressLine2;
            City = cityName;
            ZipCode = new ZipCode {Zip = zipCode};
            State = stateName;
            Country = countryName;
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(StreetAddressLine1) && string.IsNullOrEmpty(StreetAddressLine2) &&
                   string.IsNullOrEmpty(City) && (ZipCode == null || string.IsNullOrEmpty(ZipCode.Zip));
        }

        public override string ToString()
        {
            var sbAddress = new StringBuilder();
            sbAddress.Append(StreetAddressLine1);
            if (!string.IsNullOrEmpty(StreetAddressLine2))
            {
                sbAddress.Append(", " + StreetAddressLine2);
            }
            if (!string.IsNullOrEmpty(City))
            {
                sbAddress.Append(", " + City);
            }
            if (!string.IsNullOrEmpty(State))
            {
                sbAddress.Append(", " + State);
            }
            if (!string.IsNullOrEmpty(Country))
            {
                sbAddress.Append(", " + Country);
            }
            if (ZipCode != null && !string.IsNullOrEmpty(ZipCode.Zip))
            {
                sbAddress.Append(" - " + ZipCode.Zip);
            }
            return sbAddress.ToString();
        }
        public string ToShortAddressString()
        {
            var sbAddress = new StringBuilder();
            sbAddress.Append(StreetAddressLine1);
            if (!string.IsNullOrEmpty(StreetAddressLine2))
            {
                sbAddress.Append(", " + StreetAddressLine2);
            }
            if (!string.IsNullOrEmpty(City))
            {
                sbAddress.Append(", " + City);
            }
            if (!string.IsNullOrEmpty(StateCode))
            {
                sbAddress.Append(", " + StateCode);
            }
            if (!string.IsNullOrEmpty(Country))
            {
                sbAddress.Append(", " + Country);
            }
            if (ZipCode != null && !string.IsNullOrEmpty(ZipCode.Zip))
            {
                sbAddress.Append(" - " + ZipCode.Zip);
            }
            return sbAddress.ToString();
        }

    }
}