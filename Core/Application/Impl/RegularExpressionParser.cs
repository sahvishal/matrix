using System.Text.RegularExpressions;

namespace Falcon.App.Core.Application.Impl
{
    public class RegularExpressionParser : IRegularExpressionParser
    {
        public string GetSourceCode(string completeString)
        {
            const string regExSourceCode = @"([A-Za-z]\d{4}[A-Za-z])";
            var sourceCodeRegularExpression = new Regex(regExSourceCode, RegexOptions.IgnorePatternWhitespace);
            var completeMatch = sourceCodeRegularExpression.Match(completeString);
            
            return completeMatch.Value;
        }

        public string GetDate(string completeString)
        {
            const string regExDate = @"(\d{1,2}[\/\-\\]\d{1,2}[\/\-\\]\d{4})";
            var dateRegularExpression = new Regex(regExDate, RegexOptions.IgnorePatternWhitespace);
            var completeMatch = dateRegularExpression.Match(completeString);

            return completeMatch.Value;
        }

        public string GetName(string completeString)
        {
            const string regExCustomerName = @"\|(.*)";
            var nameRegularExpression = new Regex(regExCustomerName, RegexOptions.None);
            var completeMatch = nameRegularExpression.Match(completeString);

            return completeMatch.Value;
        }

    }
}