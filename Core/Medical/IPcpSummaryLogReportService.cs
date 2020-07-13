using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Medical
{
    public interface IPcpSummaryLogReportService
    {
        ListModelBase<PcpSummaryLogReportModel, PcpSummaryLogReportModelFilter> GetPcpSummaryLogReport(int pageNumber, int pageSize, ModelFilterBase filter,
            out int totalRecords);
    }
}
