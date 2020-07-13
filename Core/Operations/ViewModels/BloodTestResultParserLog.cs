using System;
using System.ComponentModel;
using System.Text;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class BloodTestResultParserLog 
    {
        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }

        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("DoB")]
        public string Dob { get; set; }

        [DisplayName("Draw Date")]
        public string DrawDate { get; set; }

        [DisplayName("Date Created")]
        public DateTime CreatedDate { get; set; }

        [Hidden]
        public StringBuilder Notes { get; set; }

        [DisplayName("Notes")]
        public string Summary { get { return Notes.ToString(); } }

        
        [Hidden]
        public bool IsSuccessful { get; set; }

        public BloodTestResultParserLog()
        {
            IsSuccessful = true;
            Notes = new StringBuilder();
        }
    }
}
