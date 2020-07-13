using System;
using Falcon.App.Core.Geo.ViewModels;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class EmailCommunicationViewModelBase
    {
        public long NotificationId { get; set; }
        public string EmailNotificationLogoRelativePath { get; set; }
        public string SupportEmail { get; set; }
        public string PhoneTollFree { get; set; }

        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public string FullBusinessName { get; set; }
        public AddressViewModel CompanyAddress { get; set; }
        public string SiteUrl { get; set; }
        public string LoginUrl { get; set; }
        public string AppUrl { get; set; }
        public string PrivacyPolicyUrl { get; set; }
        public string TermsConditionsUrl { get; set; }
        public string CopyrightText { get; set; }

        public string TestPreparationInstructions { get; set; }
        
        
      
        public DateTime NotificationDateTime { get; set; }
    }
}