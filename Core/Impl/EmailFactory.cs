using System;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Impl
{
    public class EmailFactory : IEmailFactory
    {
        public Email CreateEmail(string emailAddress)
        {
            if (emailAddress == null)
            {
                throw new ArgumentNullException("emailAddress");
            }
            string[] emailParts = emailAddress.Split("@".ToCharArray());
            if (emailParts.Length != 2)
            {
                return new Email(string.Empty, string.Empty);
            }
            return new Email(emailParts[0], emailParts[1]);
        }
    }
}