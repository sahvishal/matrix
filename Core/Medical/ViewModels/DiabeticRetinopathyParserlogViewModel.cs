using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class DiabeticRetinopathyParserlogViewModel : ViewModelBase
    {
        [DisplayName("File Name")]
        public string FileName { get; set; }

        [DisplayName("Customer Id")]
        public long CustomerId { get; set; }
        
        [DisplayName("Event Id")]
        public long EventId { get; set; }

        [DisplayName("Error Message")]
        public string ErrorMessage { get; set; }

        [DisplayName("Date Created")]
        [Format("MM/dd/yyyy")]
        public DateTime DateCreated { get; set; }
    }
}
