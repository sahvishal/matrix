using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MolinaResultExportPollingAgent : IMolinaResultExportPollingAgent
    {
        private readonly IMolinaResultExportService _molinaResultExportService;
        

        public MolinaResultExportPollingAgent(IMolinaResultExportService molinaResultExportService)
        {
            _molinaResultExportService = molinaResultExportService;
        }

        public void PollForResultExport()
        {
            _molinaResultExportService.ResultExport();

        }
    }
}