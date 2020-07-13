using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Communication.ViewModels
{
  public  class AbsenceByMemberNotificationViewModel
    {
      public AbsenceByMemberNotificationViewModel(EmailCommunicationViewModelBase emailCommunicationViewModelBase)
        {
            EmailCommunicationBaseInfo = emailCommunicationViewModelBase;
        }

        public EmailCommunicationViewModelBase EmailCommunicationBaseInfo { get; set; }

        public string Tag { get; set; }

        public long CorporateUploadId { get; set; }
    }
}
