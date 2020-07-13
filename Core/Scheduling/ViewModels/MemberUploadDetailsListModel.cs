using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class MemberUploadDetailsListModel
    {
        public IEnumerable<MemberUploadDetailsViewModel> Collection { get; set; }
        public MemberUploadDetailsListModelFilter Filter { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}
