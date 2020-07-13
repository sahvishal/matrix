using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;

namespace Falcon.App.Lib
{
    /// <summary>
    /// Summary description for CommonCode
    /// </summary>
    public class CommonCode
    {
        public void EndCCRepCall(object objPage1)
        {
            Page objPage = (Page)objPage1;
            ScriptManager.RegisterStartupScript(objPage, typeof(string), "JSCode", "CallNotes1(); ", true);
        }

        public string GetPicture(string strPicturePath, string strPictureVirtualPath)
        {
            if (File.Exists(strPicturePath))
            {
                return strPictureVirtualPath;
            }

            return "~/App/Images/No-Image-Found-small.gif";

        }

        public string FormatPhoneNumber(string strPhoneNumber)
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
        public string FormatPhoneNumberGet(string strPhoneNumber)
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
            return HttpUtility.HtmlEncode(strPhone);
        }

        /// <summary>
        /// Single line address format
        /// </summary>
        /// <param name="strAddress"></param>
        /// <param name="strSuit"></param>
        /// <param name="strCity"></param>
        /// <param name="strState"></param>
        /// <param name="strZipcode"></param>
        /// <returns></returns>
        public static string AddressSingleLine(string strAddress, string strSuit, string strCity, string strState, string strZipcode)
        {
            string strCompleteAddress = string.Empty;

            if (!string.IsNullOrEmpty(strAddress))
            {
                strCompleteAddress = strCompleteAddress + strAddress + ",&nbsp;";
            }
            if (!string.IsNullOrEmpty(strSuit))
            {
                strCompleteAddress = strCompleteAddress + strSuit + ",&nbsp;";
            }
            if (!string.IsNullOrEmpty(strCity))
            {
                strCompleteAddress = strCompleteAddress + HttpUtility.HtmlEncode(strCity) + ",&nbsp;";
            }
            if (!string.IsNullOrEmpty(strState))
            {
                strCompleteAddress = strCompleteAddress + HttpUtility.HtmlEncode(strState) + "&nbsp;&nbsp;";
            }
            if (strZipcode.Equals("0")) strZipcode = string.Empty;
            if (!string.IsNullOrEmpty(strZipcode))
            {
                strCompleteAddress = strCompleteAddress + HttpUtility.HtmlEncode(strZipcode);
            }
            strCompleteAddress = strCompleteAddress.Replace(",&nbsp;,", ",&nbsp;");
            // if found command and space 
            if (strCompleteAddress.Length >= 7)
            {
                if (strCompleteAddress.Substring(strCompleteAddress.Length - 7, 7).Equals(",&nbsp;"))
                {
                    strCompleteAddress = strCompleteAddress.Substring(0, strCompleteAddress.Length - 7);
                }
            }

            if (string.IsNullOrEmpty(strCompleteAddress)) strCompleteAddress = "-N/A-";
            else if (strCompleteAddress.Equals(",&nbsp")) strCompleteAddress = "-N/A-";
            return strCompleteAddress.Replace("&nbsp;", " ");
        }
        /// <summary>
        /// Multiline address format
        /// </summary>
        /// <param name="strAddress"></param>
        /// <param name="strSuit"></param>
        /// <param name="strCity"></param>
        /// <param name="strState"></param>
        /// <param name="strZipcode"></param>
        /// <returns></returns>
        public static string AddressMultiLine(string strAddress, string strSuit, string strCity, string strState, string strZipcode)
        {
            strCity = HttpUtility.HtmlEncode(strCity);
            strState = HttpUtility.HtmlEncode(strState);
            strZipcode = HttpUtility.HtmlEncode(strZipcode);

            string strCompleteAddress = string.Empty;
            if (!string.IsNullOrEmpty(strAddress))
            {
                strCompleteAddress = strCompleteAddress + strAddress + "<br />";
            }
            if (!string.IsNullOrEmpty(strSuit))
            {
                strCompleteAddress = strCompleteAddress + strSuit + "<br />";
            }
            if (!string.IsNullOrEmpty(strCity))
            {
                strCompleteAddress = strCompleteAddress + strCity + ",&nbsp;";
            }
            if (!string.IsNullOrEmpty(strState))
            {
                strCompleteAddress = strCompleteAddress + strState + "&nbsp;&nbsp;";
            }
            if (strZipcode.Equals("0")) strZipcode = string.Empty;
            if (!string.IsNullOrEmpty(strZipcode))
            {
                strCompleteAddress = strCompleteAddress + strZipcode;
            }
            strCompleteAddress = strCompleteAddress.Replace(",&nbsp;,", ",&nbsp;");
            strCompleteAddress = strCompleteAddress.Replace("<br /><br />", "<br />");

            // if found new line
            if (strCompleteAddress.Length >= 4)
            {
                if (strCompleteAddress.Substring(strCompleteAddress.Length - 4, 4).Equals("<br />"))
                {
                    strCompleteAddress = strCompleteAddress.Substring(0, strCompleteAddress.Length - 4);
                }
            }
            // if found command and space 
            else if (strCompleteAddress.Length >= 7)
            {
                if (strCompleteAddress.Substring(strCompleteAddress.Length - 7, 7).Equals(",&nbsp;"))
                {
                    strCompleteAddress = strCompleteAddress.Substring(0, strCompleteAddress.Length - 7);
                }
            }
            if (string.IsNullOrEmpty(strCompleteAddress)) strCompleteAddress = "-N/A-";
            else if (strCompleteAddress.Equals(",&nbsp")) strCompleteAddress = "-N/A-";
            else if (strCompleteAddress.Equals("<br />")) strCompleteAddress = "-N/A-";

            return strCompleteAddress;
        }

        public static string GetGoogleMapAddress(string address, string city, string state, string zipcode, string latitudelongitude, bool? isLatLogUseForAddressView)
        {
            string url = string.Empty;
            if (isLatLogUseForAddressView.HasValue && isLatLogUseForAddressView == true && (!string.IsNullOrEmpty(latitudelongitude)))
            {
                url = "http://maps.google.com/maps?f=q&hl=en&geocode=&q=" + latitudelongitude + "(" + address + ")" + "&ie=UTF8&z=16";
            }
            else if ((!string.IsNullOrEmpty(address)) && (!string.IsNullOrEmpty(city)) && (!string.IsNullOrEmpty(state)) && (!string.IsNullOrEmpty(zipcode)))
            {
                url = "http://maps.google.com/maps?f=q&hl=en&geocode=&q=" + address.Trim() + "," + city.Trim() + "," + state.Trim() + "," + zipcode.Trim() + "&ie=UTF8&z=16";
            }
            return url;
        }
        //TODO: Need to delete after changes on all pages.
        public static string GetGoogleAddressNotVerifiedJtip()
        {
            const string googleAddressJtip = "<a href=\"#\" class=\"jtip\" title='Google Map Address Verification |<span class=\"smallttextnowidth_default\">The Event Host Address is not verified using google &quot;Map&quot; Location.</span>' style=\"font-size: 12px; font-weight: bold; text-decoration: none\">?</a>";
            return googleAddressJtip;
        }
        //TODO: Need to change this.
        public static string GetGoogleAddressNotVerifiedJtipHostDetails()
        {
            const string googleAddressJtip = "<a href=\"#\" class=\"jtip\" title='Google Map Address Verification | The Host Address is not verified from google map.'><img src=\"/App/Images/info-icon.gif\" alt=\"Info\" title=\"Info\"/></a>";
            return googleAddressJtip;
        }
        /// <summary>
        /// Sets the left navigation.
        /// </summary>
        /// <param name="dtTable">The dt table.</param>
        /// <param name="htmlGc">The HTML gc.</param>
        public static void SetLeftNavigation(DataTable dtTable, HtmlGenericControl htmlGc)
        {
            if (dtTable.Rows.Count > 0)
            {
                var sbQuickLinks = new StringBuilder();
                foreach (DataRow dr in dtTable.Rows)
                {
                    sbQuickLinks.AppendLine("<div class=\"leftnav\">");
                    sbQuickLinks.AppendLine("<img src=\"/App/Images/left-nav-arrow.gif\" alt=\"\" />");
                    sbQuickLinks.AppendLine("<a title='" + HttpUtility.HtmlEncode(dr["Name"]) + "' href='" + HttpUtility.HtmlEncode(dr["TargetURL"]) + "'>" + HttpUtility.HtmlEncode(dr["Name"]) + "</a>");
                    sbQuickLinks.AppendLine("</div>");
                }
                htmlGc.InnerHtml = sbQuickLinks.ToString();
            }
        }



    }

}