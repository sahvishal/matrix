using System.ComponentModel;
using System.Text.RegularExpressions;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Core.ValueTypes
{
    [NoValidationRequired]
    public class PhoneNumber
    {
        public PhoneNumberType PhoneNumberType { get; set; }

        [DisplayName("Country")]
        public CountryCode CountryCode { get; set; }

        [DisplayName("Area")]
        public string AreaCode { get; set; }

        [DisplayName("Number")]
        public string Number { get; set; }
        [IgnoreAudit]
        public string InternationalPhoneNumber { get { return "+" + (int)CountryCode + " " + AreaCode + " " + Number; } }
        [IgnoreAudit]
        public string DomesticPhoneNumber
        {
            get
            {
                string areaCodeString = string.Empty;
                if (!AreaCode.IsNullOrEmpty())
                {
                    areaCodeString = AreaCode + "-";
                }
                return areaCodeString + Number;
            }
        }

        // Used in Ajax calls.
        public PhoneNumber()
            : this(string.Empty, string.Empty, PhoneNumberType.Unknown)
        { }


        public PhoneNumber(string areaCode, string number, PhoneNumberType phoneNumberType)
            : this(CountryCode.UnitedStatesAndCanada, areaCode, number, phoneNumberType)
        { }

        public PhoneNumber(CountryCode countryCode, string areaCode, string number, PhoneNumberType phoneNumberType)
        {
            AreaCode = areaCode;
            Number = number;
            PhoneNumberType = phoneNumberType;
            CountryCode = countryCode;
        }

        public override string ToString()
        {
            return DomesticPhoneNumber;
        }

        //Bidhan: Need to refine this
        public PhoneNumber ToNumber()
        {
            Number = ToNumber(Number);
            return this;
        }

        public static string ToNumber(string number)
        {
            var cleanPhone = number.Replace("(", "").Replace(")", "").Replace("-", "");
            cleanPhone = cleanPhone.Replace("_", "");
            if (cleanPhone.Length != 10)
                number = "";
            else
                number = cleanPhone;

            return number;
        }

        public static PhoneNumber Create(string phoneNumber, PhoneNumberType phoneNumberType)
        {

            const int AREA_CODE_LENGTH = 3;
            const int MINIMUM_PHONE_NUMBER_LENGTH = 10;
            const int MAXIMUM_PHONE_NUMBER_LENGTH = 13;

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

        [IgnoreAudit]
        public string FormatPhoneNumber
        {
            get
            {
                const int AREA_CODE_LENGTH = 3;
                string areaCodeString = string.Empty;
                string number = string.Empty;
                if (!AreaCode.IsNullOrEmpty())
                {
                    areaCodeString = AreaCode + "-";
                }
                if (Number.Length > AREA_CODE_LENGTH)
                    number = Number.Substring(0, AREA_CODE_LENGTH) + "-" + Number.Substring(AREA_CODE_LENGTH);
                else
                    number = Number;

                return areaCodeString + number;
            }
        }

        [IgnoreAudit]
        public string GlobalPhoneNumberFormat
        {
            get
            {
                const int AREA_CODE_LENGTH = 3;
                const int Length_of_Major = 3;
                string number = string.Empty;

                if (Number.Length >= 10)
                {
                    number = string.Format("({0}){1}-{2}", Number.Substring(0, AREA_CODE_LENGTH), number.Substring(AREA_CODE_LENGTH, Length_of_Major), number.Substring(Length_of_Major));
                }
                else if (Number.Length >= 7 && Number.Length < 10)
                {
                    number = string.Format("({0}){1}-{2}", AreaCode, Number.Substring(0, Length_of_Major), Number.Substring(Length_of_Major));
                }

                return string.Format("+{0}{1}", (long)CountryCode, number);
            }
        }

        [IgnoreAudit]
        public string FaxNumberFormat
        {
            get
            {
                const int AREA_CODE_LENGTH = 3;
                const int Length_of_Major = 3;
                string number = string.Empty;

                if (Number.Length >= 10)
                {
                    number = string.Format("{0}-{1}-{2}", Number.Substring(0, AREA_CODE_LENGTH), number.Substring(AREA_CODE_LENGTH, Length_of_Major), number.Substring(Length_of_Major));
                }
                else if (Number.Length >= 7 && Number.Length < 10)
                {
                    number = string.Format("{0}-{1}-{2}", AreaCode, Number.Substring(0, Length_of_Major), Number.Substring(Length_of_Major));
                }

                return string.Format("+{0}{1}", (long)CountryCode, number);
            }
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(Number);
        }
    }
}