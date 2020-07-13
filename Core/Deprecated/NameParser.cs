using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Deprecated
{
    public class NameParser
    {
        public Name ParseName(string nameToParse)
        {
            return ParseName(nameToParse, ' ');
        }

        public Name ParseName(string nameToParse, char delimiter)
        {
            var name = new Name {FirstName = nameToParse};

            if (nameToParse.Contains(delimiter.ToString()))
            {
                int spacePosition = nameToParse.IndexOf(delimiter);
                name.FirstName = nameToParse.Substring(0, spacePosition);
                name.LastName = nameToParse.Substring(spacePosition + 1);
            }

            return name;
        }
    }
}