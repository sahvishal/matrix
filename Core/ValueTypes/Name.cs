using System.ComponentModel;

namespace Falcon.App.Core.ValueTypes
{
    public class Name
    {       
        [DisplayName("First")]
        public string FirstName { get; set; }
        
        [DisplayName("Middle")]
        public string MiddleName { get; set; }


        [DisplayName("Last")]
        public string LastName { get; set; }
        
        public string FullName { get { return ToString(); } }

        public Name()
            : this(string.Empty, string.Empty, string.Empty)
        {}

        public Name(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public Name(string fullName)
        {
            if (fullName.Length < 1) return;

            var nameParts = fullName.Split(new[] {' '});
            if(nameParts.Length < 1) return;

            FirstName = nameParts[0];
            if (nameParts.Length > 1)
            {
                MiddleName = nameParts.Length > 2 ? nameParts[1] : string.Empty;
                LastName = nameParts.Length > 2 ? nameParts[2] : nameParts[1];
            }
        }

        public override string ToString()
        {
            string middleName = MiddleName;
            if (!string.IsNullOrEmpty(MiddleName) && !string.IsNullOrEmpty(LastName))
            {
                middleName = " " + MiddleName + " ";
            }
            else if (!string.IsNullOrEmpty(LastName))
            {
                middleName = " ";
            }
            return (FirstName + middleName + LastName).Trim();
        }
    }
}