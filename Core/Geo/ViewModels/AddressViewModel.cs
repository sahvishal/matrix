using System.ComponentModel;
using System.Text;

namespace Falcon.App.Core.Geo.ViewModels
{
    public class AddressViewModel
    {
        [DisplayName("Street")]
        public string StreetAddressLine1 { get; set; }
        [DisplayName("Apt/Suite")]
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

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
            if (!string.IsNullOrEmpty(ZipCode))
            {
                sbAddress.Append(" - " + ZipCode);
            }
            return sbAddress.ToString();
        }

        public string MaptoLocation()
        {
            var sbAddress = new StringBuilder();
            sbAddress.Append(StreetAddressLine1);
            if (!string.IsNullOrEmpty(City))
            {
                sbAddress.Append(", " + City);
            }
            if (!string.IsNullOrEmpty(State))
            {
                sbAddress.Append(", " + State);
            }
            if (!string.IsNullOrEmpty(ZipCode))
            {
                sbAddress.Append(", " + ZipCode);
            }
            return sbAddress.ToString();
        }

        public string ToShortAddressString(bool useAddressLine2 = true)
        {
            var sbAddress = new StringBuilder();
            sbAddress.Append(StreetAddressLine1);
            if (!string.IsNullOrEmpty(StreetAddressLine2) && useAddressLine2)
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
            if (!string.IsNullOrEmpty(ZipCode))
            {
                sbAddress.Append(" - " + ZipCode);
            }
            return sbAddress.ToString();
        }
        public long StateId { get; set; }
    }
}