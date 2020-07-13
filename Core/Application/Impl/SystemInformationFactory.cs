using System;
using System.Linq;

namespace Falcon.App.Core.Application.Impl
{
    public class SystemInformationFactory : ISystemInformationFactory
    {
        public string GetFormattedVersionString(string rawVersionString)
        {
            if (rawVersionString == null)
            {
                throw new ArgumentNullException("rawVersionString");
            }
            if (rawVersionString.Split(".".ToCharArray()).Count() != 4)
            {
                throw new ArgumentException("Given string must be in format A.B.C.D in order to be parsed.");
            }
            string versionNumber = rawVersionString.Substring(0, rawVersionString.LastIndexOf('.'));
            string buildNumber = rawVersionString.Split(".".ToCharArray()).LastOrDefault();
            return string.Format("Version {0} [Build: {1}]", versionNumber, buildNumber);
        }
    }
}