using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Falcon.App.Core.Geo.ViewModels
{
    public class AddressEditModel
    {

        [UIHint("Hidden")]
        public long Id { get; set; }

        [DisplayName("Street")]
        public string StreetAddressLine1 { get; set; }

        [DisplayName("Apt/Suite")]
        public string StreetAddressLine2 { get; set; }

        public string City { get; set; }

        [DisplayName("State")]
        [UIHint("State")]
        public long StateId { get; set; }

        [DisplayName("Country")]
        [UIHint("Country")]
        public long CountryId { get; set; }

        [DisplayName("Zip Code")]
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
            if (ZipCode != null && !string.IsNullOrEmpty(ZipCode))
            {
                sbAddress.Append(" - " + ZipCode);
            }
            return sbAddress.ToString();
        }

        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(StreetAddressLine1) && string.IsNullOrEmpty(StreetAddressLine2) && string.IsNullOrEmpty(City) && string.IsNullOrEmpty(ZipCode) && StateId < 1)
                return true;
            return false;
        }

    }
}