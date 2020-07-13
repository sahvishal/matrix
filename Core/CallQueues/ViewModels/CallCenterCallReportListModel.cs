using Falcon.App.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallCenterCallReportListModel : ListModelBase<CallCenterCallReportModel, CallCenterCallReportModelFilter>
    {
        public override IEnumerable<CallCenterCallReportModel> Collection { get; set; }

        public override CallCenterCallReportModelFilter Filter { get; set; }
    }
}
