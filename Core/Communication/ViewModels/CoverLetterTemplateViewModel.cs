using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class CoverLetterTemplateViewModel
    {
        public CoverLetterTemplateViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public string CustomerName { get; set; }
        public string LetterDate { get; set; }
        public string DoctorSignatureFilePathUrl { get; set; }
        public string HospitalPartnerLogoFilePathUrl { get; set; }
        public string PcpName { get; set; }
        
        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }
    }
}