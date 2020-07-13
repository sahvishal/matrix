using System;

namespace Falcon.Entity.Other
{
    public class PhoneFormat
    {
        public static string FormatPhoneNumber(string strPhoneNumber)
        {
            string strPhone = string.Empty;
            if (!string.IsNullOrEmpty(strPhoneNumber))
            {
                //// remove the spl character if numbner is properly formatted.
                strPhone = strPhoneNumber.Replace("(", "").Replace(")", "").Replace("-", "");
                strPhone = strPhone.Replace("_", "");

                // Empty phone no in case it is wrong phone no....
                if (strPhone.Length != 10)
                    strPhone = "";
            }

            return strPhone;
        }
        public static string FormatPhoneNumberGet(string strPhoneNumber)
        {
            string strPhone = string.Empty;
            if (!string.IsNullOrEmpty(strPhoneNumber))
            {
                // remove the spl character if numbner is properly formatted.
                strPhone = strPhoneNumber.Replace("(", "").Replace(")", "").Replace("-", "");
                strPhone = strPhone.Replace("_", "");

                Char[] chr = strPhone.ToCharArray();
                if (chr.Length == 10)
                {
                    strPhone = "(" + chr[0] + chr[1] + chr[2] + ")-" + chr[3] + chr[4] + chr[5] + "-" +
                        chr[6] + chr[7] + chr[8] + chr[9];
                }
                // Empty phone number in case it is wrong phone number...
                else
                {
                    strPhone = string.Empty;
                }
            }
            return strPhone;
        }
    }
}
