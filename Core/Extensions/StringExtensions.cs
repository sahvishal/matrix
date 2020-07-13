using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace Falcon.App.Core.Extensions
{
    public static class StringExtensions
    {
        public static int LineCount(this string stringToUse)
        {
            if (string.IsNullOrEmpty(stringToUse))
            {
                return 0;
            }
            return new Regex(Environment.NewLine).Matches(stringToUse).Count + 1;
        }

        public static string AddSpecialCharacter(this string dataString, int interval, string specialCharacter)
        {
            if (!string.IsNullOrEmpty(dataString))
            {
                var counter = 0;
                while (interval < dataString.Length)
                {
                    dataString = dataString.Insert(interval + counter, specialCharacter);
                    interval += interval;
                    counter += 1;
                }
            }
            return dataString;
        }

        public static decimal ToDecimal(this string stringToUse)
        {
            if (!string.IsNullOrEmpty(stringToUse))
            {
                decimal convertedValue;
                if (decimal.TryParse(stringToUse, out convertedValue))
                {
                    return convertedValue;
                }
            }
            return default(decimal);
        }

        public static int ToInt(this string stringToUse)
        {
            if (!string.IsNullOrEmpty(stringToUse))
            {
                int convertedValue;
                if (int.TryParse(stringToUse, out convertedValue))
                {
                    return convertedValue;
                }
            }
            return default(int);
        }

        public static long ToLong(this string stringToUse)
        {
            if (!string.IsNullOrEmpty(stringToUse))
            {
                long convertedValue;
                if (long.TryParse(stringToUse, out convertedValue))
                {
                    return convertedValue;
                }
            }
            return default(long);
        }

        public static string GetInitial(this string name)
        {
            var splittedStrings = name.ToUpper().Split(new char[] { ' ' }).ToList();

            return splittedStrings.Count > 1
                ? string.Format("{0} {1}", splittedStrings.First().Substring(0, 1), splittedStrings.Last().Substring(0, 1))
                : splittedStrings.First().Substring(0, 1);

        }

        public static string ToUppercaseInitalLetter(this string dataString, bool applyToAllWords = true)
        {
            if (string.IsNullOrEmpty(dataString) || dataString.Trim().Length < 1) return dataString;

            var words = dataString.Split(new[] { ' ' });

            if (words.Length < 1) return dataString;

            if (applyToAllWords)
            {
                var newWordsFormation = words.Select(word => word.Substring(0, 1).ToUpper() + word.Substring(1)).ToArray();
                return string.Join(" ", newWordsFormation);
            }

            var newWord = words.First().Substring(0, 1).ToUpper() + words.First().Substring(1);
            if (words.Length < 2)
                return newWord;

            dataString = newWord + dataString.Substring(dataString.IndexOf(" "));

            return dataString;
        }

    }
}