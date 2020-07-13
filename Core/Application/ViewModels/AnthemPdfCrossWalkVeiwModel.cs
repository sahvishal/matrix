using System;
using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Application.ViewModels
{
    public class AnthemPdfCrossWalkVeiwModel
    {
        [DisplayName("PDF File Name")]
        public string FileName { get; set; }

        [DisplayName("Date of Assessment")]
        [Format("MM/dd/yyyy")]
        public DateTime DateOfAssessment { get; set; }

        
        [DisplayName("Date Transferred")]
        [Format("MM/dd/yyyy")]
        public DateTime DateOfTransferred { get; set; }

        [DisplayName("Page Count")]
        public int PageCount { get; set; }

        [DisplayName("DCN")]
        public string Dcn { get; set; }

        [DisplayName("Batch")]
        [Hidden]
        public string Batch { get; set; }
    }
}