using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Geo.Impl
{
    public class ZipCodeParser : IZipCodeParser
    {
        public List<string> ParseStringIntoZipCodes(string zipCodeString)
        {
            var filteredZipCodeString = Regex.Replace(zipCodeString, "\\D", " ");
            var zipCodes = new List<string>();
            foreach (var zipCode in filteredZipCodeString.Split(" ".ToCharArray()))
            {
                if (zipCode.Length == 5)
                {
                    zipCodes.Add(zipCode);
                }
            }
            return zipCodes;
        }

        public string ParseZipCodesIntoString(IEnumerable<ZipCode> zipCodes)
        {
            var zipCodeStringBuilder = new StringBuilder();
            foreach (ZipCode zipCode in zipCodes)
            {
                zipCodeStringBuilder.AppendFormat("{0}, ", zipCode.Zip);
            }
            return zipCodeStringBuilder.Length > 0 ? zipCodeStringBuilder.ToString().Substring(0, zipCodeStringBuilder.Length - 2) : 
                string.Empty;
        }
    }
}