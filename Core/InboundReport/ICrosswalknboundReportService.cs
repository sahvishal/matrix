using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.InboundReport
{
    public interface ICrosswalkInboundReportService
    {
        ListModelBase<CrosswalkInboundViewModel, CrosswalkInboundFilter> GetCrosswalkInboundReportList(CrosswalkInboundFilter filter, ILogger logger);

        ListModelBase<CrosswalkLabInboundViewModel, CrosswalkLabInboundFilter> GetCrosswalkLabInboundReportList(CrosswalkLabInboundFilter filter);
    }
}
