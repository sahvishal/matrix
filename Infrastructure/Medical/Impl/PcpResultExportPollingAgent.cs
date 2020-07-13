using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PcpResultExportPollingAgent : IPcpResultExportPollingAgent
    {
        private readonly IPcpResultExportService _pcpResultExportService;

        public PcpResultExportPollingAgent(IPcpResultExportService pcpResultExportService)
        {
            _pcpResultExportService = pcpResultExportService;
        }

        public void PollForResultExport()
        {
            _pcpResultExportService.ResultExport();

        }
    }
}