using Falcon.App.Core.ValueTypes;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class ChaperoneFormViewModel
    {
        public long CustomerId { get; set; }
        public Name CustomerName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public IEnumerable<ChaperoneQuestionAnswerViewModel> Answers { get; set; }
        public string SignatureImageUrl { get; set; }
        public string StaffSignatureImageUrl { get; set; }
        public DateTime? EventDate { get; set; }
    }
}
