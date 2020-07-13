using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Scheduling.ViewModels
{

    [NoValidationRequired]
    public class MemberUploadDetailsViewModel : ViewModelBase
    {
        public long Id { get; set; }

        public FileModel File { get; set; }

        public DateTime UploadTime { get; set; }

        public long SuccessfullCustomer { get; set; }

        public long FailedCustomer { get; set; }

        public FileModel FailedFile { get; set; }
    }
}
