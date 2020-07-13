using System.Text;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianMasterViewModel
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PrefixText { get; set; }
        public string SuffixText { get; set; }
        public string CredentialText { get; set; }
        public string PracticeAddress1 { get; set; }
        public string PracticeAddress2 { get; set; }
        public string PracticeCity { get; set; }
        public string PracticeState { get; set; }
        public string PracticeZip { get; set; }
        public PhoneNumber PracticePhone { get; set; }
        public PhoneNumber PracticeFax { get; set; }
        public string MailingAddress1 { get; set; }
        public string MailingAddress2 { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZip { get; set; }

        public string ToShortAddressString()
        {
            var sbAddress = new StringBuilder();
            sbAddress.Append(PracticeAddress1);
            if (!string.IsNullOrEmpty(PracticeAddress2))
            {
                sbAddress.Append(", " + PracticeAddress2);
            }
            if (!string.IsNullOrEmpty(PracticeCity))
            {
                sbAddress.Append(", " + PracticeCity);
            }
            if (!string.IsNullOrEmpty(PracticeState))
            {
                sbAddress.Append(", " + PracticeState);
            }            
            if (!string.IsNullOrEmpty(PracticeZip))
            {
                sbAddress.Append(" - " + PracticeZip);
            }
            return sbAddress.ToString();
        }

        public string ToShortMailingAddressString()
        {
            var sbAddress = new StringBuilder();
            sbAddress.Append(MailingAddress1);
            if (!string.IsNullOrEmpty(MailingAddress2))
            {
                sbAddress.Append(", " + MailingAddress2);
            }
            if (!string.IsNullOrEmpty(MailingCity))
            {
                sbAddress.Append(", " + MailingCity);
            }
            if (!string.IsNullOrEmpty(MailingState))
            {
                sbAddress.Append(", " + MailingState);
            }            
            if (!string.IsNullOrEmpty(MailingZip))
            {
                sbAddress.Append(" - " + MailingZip);
            }
            return sbAddress.ToString();
        }

        public string NameString()
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

            string prefixText = "";
            if (!string.IsNullOrEmpty(PrefixText))
                prefixText = PrefixText + " ";

            string suffixText = "";
            if (!string.IsNullOrEmpty(SuffixText))
                suffixText = " " + SuffixText;

            return (prefixText + FirstName + middleName + LastName + suffixText).Trim();
        }
    }
}
