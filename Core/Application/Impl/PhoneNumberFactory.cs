using System.Text.RegularExpressions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Application.Impl
{
    public class PhoneNumberFactory : IPhoneNumberFactory
    {
        private const int AREA_CODE_LENGTH = 3;
        private const int MINIMUM_PHONE_NUMBER_LENGTH = 10;
        private const int MAXIMUM_PHONE_NUMBER_LENGTH = 13;

        public PhoneNumber CreatePhoneNumber(string phoneNumber, PhoneNumberType phoneNumberType)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return new PhoneNumber(string.Empty, string.Empty, PhoneNumberType.Unknown);
            }
            string filteredNumber = Regex.Replace(phoneNumber, "\\D", "");
            if (filteredNumber.Length < MINIMUM_PHONE_NUMBER_LENGTH || 
                filteredNumber.Length > MAXIMUM_PHONE_NUMBER_LENGTH)
            {
                return new PhoneNumber(string.Empty, string.Empty, PhoneNumberType.Unknown);
            }

            int countryCodeLength = filteredNumber.Length - MINIMUM_PHONE_NUMBER_LENGTH;
            CountryCode countryCode = (countryCodeLength > 0) ? 
                (CountryCode)(int.Parse(filteredNumber.Substring(0, countryCodeLength)))
                : CountryCode.UnitedStatesAndCanada;
            string areaCode = filteredNumber.Substring(countryCodeLength, AREA_CODE_LENGTH);
            string number = filteredNumber.Substring(countryCodeLength + AREA_CODE_LENGTH, 
                filteredNumber.Length - countryCodeLength - AREA_CODE_LENGTH);
            return new PhoneNumber(countryCode, areaCode, number, phoneNumberType);
        }
    }
}