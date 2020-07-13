using Falcon.App.Core.Application.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class MemberUploadDetailsListModelFilter
    {
        public DateTime? FromUploadDate { get; set; }
        public DateTime? ToUploadDate { get; set; }
        public long? SourceId { get; set; }
    }

}
