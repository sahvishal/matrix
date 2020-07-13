using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Application.Impl
{
    [DefaultImplementation]
    public class CSVSanitizer : ICSVSanitizer
    {
        public string EscapeString(string toEscape)
        {
            if (toEscape == null)
            {
                return "";
            }
            return '"' + toEscape.Replace("\"", @"""""") + '"';
        }
    }
}