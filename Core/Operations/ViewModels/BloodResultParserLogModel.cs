using System.ComponentModel;
using System.Text;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class BloodResultParserLogModel
    {
        [DisplayName("Event ID")]
        public long EventId { get; set; }

        [DisplayName("Medical ID")]
        public string MedicalId { get; set; }

        [DisplayName("Barcode ID")]
        public long CustomerId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("DOB")]
        public string Dob { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Collection Date")]
        public string CollectionDate { get; set; }

        [DisplayName("Receipt Date")]
        public string ReceiptDate { get; set; }

        [DisplayName("Testing Date")]
        public string TestingDate { get; set; }

        [DisplayName("Report Date")]
        public string ReportDate { get; set; }

        [Hidden]
        public StringBuilder Notes { get; set; }

        [DisplayName("Notes")]
        public string Summary { get { return Notes.ToString(); } }

        
        [Hidden]
        public bool IsSuccessful { get; set; }

        public BloodResultParserLogModel()
        {
            IsSuccessful = true;
            Notes = new StringBuilder();
        }
    }
}
