using System;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using Falcon.App.Core.Domain.ViewData;


namespace Falcon.App.Core.Deprecated.Utility
{
    public class CommonClass
    {
        /// <summary>
        /// For complete address display on grids
        /// </summary>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="country"></param>
        /// <param name="zip"></param>
        /// <returns></returns>
        public static string FormatAddress(string address1, string address2, string city, string state, string country, string zip)
        {
            StringBuilder sbAddress = new StringBuilder();

            sbAddress.Append(address1);

            if (address2 != null && address2 != "")
                sbAddress.Append(", " + address2);

            if (city != null && city != "")
                sbAddress.Append(", " + city);

            if (state != null && state != "")
                sbAddress.Append(", " + state);

            if (country != null && country != "")
                sbAddress.Append(", " + country);

            if (zip != null && zip != "")
                sbAddress.Append(" - " + zip);

            return sbAddress.ToString();
        }

        /// <summary>
        /// For complete address display on grids
        /// </summary>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <returns></returns>
        public static string FormatAddress(string address1, string address2, string city, string state, string zip)
        {
            StringBuilder sbAddress = new StringBuilder();

            sbAddress.Append(address1);

            if (address2 != null && address2 != "")
                sbAddress.Append(", " + address2);

            if (city != null && city != "")
                sbAddress.Append(", " + city);

            if (state != null && state != "")
                sbAddress.Append(", " + state);

            if (zip != null && zip != "")
                sbAddress.Append(" - " + zip);

            return HttpUtility.HtmlEncode(sbAddress.ToString());
        }

        /// <summary>
        /// For complete name display on grids
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="middlename"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static string FormatName(string firstName, string middlename, string lastName)
        {
            StringBuilder sbName = new StringBuilder();
            sbName.Append(firstName); 

            if(middlename != null && middlename != "")
                sbName.Append(" " + middlename);

            if (lastName != null && lastName != "")
                sbName.Append(" " + lastName);

            return sbName.ToString();
        }


        public static DataSet DecompressDataSet(byte[] bytDs, out int len)
        {
            System.Diagnostics.Debug.Write(bytDs.Length.ToString());
            DataSet outDs = new DataSet();
            MemoryStream inMs = new MemoryStream(bytDs);
            inMs.Seek(0, 0);
            DeflateStream zipStream = new DeflateStream(inMs, CompressionMode.Decompress, true);
            byte[] outByt = ReadFullStream(zipStream);
            zipStream.Flush();
            zipStream.Close();
            MemoryStream outMs = new MemoryStream(outByt);
            outMs.Seek(0, 0);
            outDs.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bf = new BinaryFormatter();
            len = (int)outMs.Length;
            outDs = (DataSet)bf.Deserialize(outMs, null);
            return outDs;
        }
        private static byte[] ReadFullStream(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }

            }
        }

        public static byte[] CompressDataSet(DataSet ds)
        {
            ds.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, ds);
            byte[] inbyt = ms.ToArray();
            System.IO.MemoryStream objStream = new MemoryStream();
            System.IO.Compression.DeflateStream objZS = new System.IO.Compression.DeflateStream(objStream, System.IO.Compression.CompressionMode.Compress);
            objZS.Write(inbyt, 0, inbyt.Length);
            objZS.Flush();
            objZS.Close();
            return objStream.ToArray();
        }

        /// <summary>
        /// Generates PDF from an aspx page.
        /// </summary>
        /// <param name="pageurl"></param>
        /// <param name="servermappath"></param>




        /// <summary>
        /// To get Start Date and End date of any week in which our input date comes
        /// </summary>
        /// <param name="currentDate">datetime</param>
        /// <param name="startDate">out datetime</param>
        /// <param name="endDate">out datetime</param>
        public static void GetWeekDates(DateTime currentDate, out DateTime startDate, out DateTime endDate)
        {
            DateTime currdate = Convert.ToDateTime("07/29/2008");
            int pastdayscount = 0;

            if (currentDate.DayOfWeek == DayOfWeek.Tuesday)
                pastdayscount = 1;
            else if (currentDate.DayOfWeek == DayOfWeek.Wednesday)
                pastdayscount = 2;
            else if (currentDate.DayOfWeek == DayOfWeek.Thursday)
                pastdayscount = 3;
            else if (currentDate.DayOfWeek == DayOfWeek.Friday)
                pastdayscount = 4;
            else if (currentDate.DayOfWeek == DayOfWeek.Saturday)
                pastdayscount = 5;
            else if (currentDate.DayOfWeek == DayOfWeek.Sunday)
                pastdayscount = 6;

            startDate = currentDate.AddDays(-pastdayscount);
            endDate = currentDate.AddDays(-pastdayscount + 6);
        }
    
    
    public static string  GetOrderPackageNameForDisplay(EventCustomerPackageTestDetailViewData eventCustomerPackageTestDetailViewData)
    {
        var package = new StringBuilder();
        if (eventCustomerPackageTestDetailViewData.Package != null && eventCustomerPackageTestDetailViewData.Package.Tests.Count > 0)
        {
            package.Append(
                "<tr><td width=\"17%\" valign=\"top\">Package:</td><td width=\"83%\" valign=\"top\"> <b>[PackageName]</b> <ul style=\"margin:0 0 0 15px;padding:0 0 0 10px\">");
         
            package = package.Replace("[PackageName]",eventCustomerPackageTestDetailViewData.Package.Name);

            
            foreach (var test in eventCustomerPackageTestDetailViewData.Package.Tests)
            {
                package.Append("<li style=\"margin: 0px 10px; padding: 0px 0px; list-style: disc;\">" + test.Name + "</li>");
            }
            package.Append("</ul></td></tr><tr><td colspan=\"2\">&nbsp;</td></tr>");
        }

        return package.ToString();
    }
    public static string GetOrderTestNameForDisplay(EventCustomerPackageTestDetailViewData eventCustomerPackageTestDetailViewData)
    {
        var additionalTest=new StringBuilder() ;
        if (eventCustomerPackageTestDetailViewData.Tests.Count > 0)
        {
            if (eventCustomerPackageTestDetailViewData.Package != null && eventCustomerPackageTestDetailViewData.Package.Tests.Count > 0)
                additionalTest.Append("<tr><td width=\"17%\" valign=\"top\">Additional Test(s):</td><td valign=\"top\"><ul style=\"margin:0 0 0 15px;padding:0 0 0 10px\"><strong>");
            else additionalTest.Append("<tr><td width=\"17%\" valign=\"top\">Test(s):</td><td valign=\"top\"><ul style=\"margin:0 0 0 15px;padding:0 0 0 10px\"><strong>");

            foreach (var test in eventCustomerPackageTestDetailViewData.Tests)
            {
                additionalTest.Append("<li style=\"margin: 0px 10px; padding: 0px 0px; list-style: disc;\">" + test.Name + "</li>");
            }
            additionalTest.Append("</strong></ul></td></tr><tr><td colspan=\"2\">&nbsp;</td></tr>");
        }
        return additionalTest.ToString();
    }
    }
}
