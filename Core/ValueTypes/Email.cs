using System;

namespace Falcon.App.Core.ValueTypes
{
    public class Email
    {
        public string Address { get; set; }
        public string DomainName { get; set; }

        // Used in Ajax calls.
        public Email()
            : this(string.Empty, string.Empty)
        { }

        public Email(string email)
        {
            //if (email.IndexOf("@") < 1 || email.IndexOf("@") == email.Length - 1) throw new Exception("Invalid Email Id");
            if (email.Contains("@"))
            {
                var emailParts = email.Split(new char[] { '@' });
                if (emailParts.Length == 2)
                {
                    Address = emailParts[0];
                    DomainName = emailParts[1];
                }
                else
                    Address = email;
            }
            else
            {
                Address = email;
            }
        }

        public Email(string addressPart, string domainNamePart)
        {
            Address = addressPart;
            DomainName = domainNamePart;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Address) && !string.IsNullOrEmpty(DomainName))
            {
                return Address + "@" + DomainName;
            }
            else return Address;

            //return string.Empty;
        }
    }
}