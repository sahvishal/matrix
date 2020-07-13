using System;
using System.Text;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.Application.Impl
{
    [DefaultImplementation]
    public class RandomStringGenerator
        : IRandomStringGenerator
    {
        public string GetRandomString(int length)
        {
            var ranString = new StringBuilder(length);
            for (int i = 0; i < length; ++i)
            {
                int charIndex;
                // allow only digits and letters
                do
                {
                    charIndex = RandomNumberHelper.Between(48, 123);
                } while (!((charIndex >= 48 && charIndex <= 57)
                    || (charIndex >= 65 && charIndex <= 90)
                    || (charIndex >= 97 && charIndex <= 122))
                );

                // add the random char to the ranString being built
                ranString.Append(Convert.ToChar(charIndex));
            }
            return ranString.ToString();
        }

        public string GetRandomNumericString(int length)
        {
            var ranString = new StringBuilder(length);

            string strRandomNumber = string.Empty;

            for (int i = 0; i < length; ++i)
            {
                int charIndex = RandomNumberHelper.Between(1, 9999);
                if (i > 1 && strRandomNumber.Length > length)
                    break;
                strRandomNumber = strRandomNumber + charIndex;
            }

            ranString.Append(strRandomNumber.Substring(0, length));

            return ranString.ToString();
        }

        public string GetRandomUpperCaseNumericString(int length)
        {
            var ranString = new StringBuilder(length);
            for (int i = 0; i < length; ++i)
            {
                int charIndex;
                // allow only digits and upper case letters
                // also dont allow 0,1,I and O
                do
                {
                    charIndex = RandomNumberHelper.Between(50, 90);
                } while (!((charIndex >= 50 && charIndex <= 57)
                           || (charIndex >= 65 && charIndex <= 72)
                           || (charIndex >= 74 && charIndex <= 78)
                           || (charIndex >= 80 && charIndex <= 90)));


                // add the random char to the ranString being built
                ranString.Append(Convert.ToChar(charIndex));
            }
            return ranString.ToString();
        }
    }
}