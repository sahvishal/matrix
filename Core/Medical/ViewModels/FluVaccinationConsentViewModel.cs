using System;
using System.Collections.Generic;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class FluVaccinationConsentViewModel
    {
        public long CustomerId { get; set; }
        public Name CustomerName { get; set; }
        public int Gender { get; set; }
        public DateTime? DateofBirth { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }
        public int Race { get; set; }

        public AddressViewModel Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public long EventId { get; set; }
        public DateTime EventDate { get; set; }
        public AddressViewModel EventAddress { get; set; }

        public IEnumerable<FluConsentQuestionAnswerEditModel> Answers { get; set; }

        public string SignatureImageUrl { get; set; }
        public string ConsentSignedDate { get; set; }

        public string ClinicalProviderSignatureImageUrl { get; set; }
    }
}
