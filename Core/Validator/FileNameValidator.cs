using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Falcon.App.Core.Validator
{
    public static class FileNameValidator
    {
        public static bool IsValid(String fileName)
        {
            const int maxFileNameLength = 128;
            if (fileName.Length > maxFileNameLength)
                return false;

            if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                return false;

            const string pattern =
            "(^(PRN|AUX|CLOCK|NUL|CON|COM[1-9]|LPT[1-9]|(\\.+)$)(\\..*)?$)|(([\\x00-\\x1f\\\\?*:\";‌​|/<>‌​])+)|([\\. ]+)";

            bool isMatch = Regex.IsMatch(fileName, pattern);
            //if (!isMatch)
            return isMatch;


        }
    }
}