using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class WellmedResultExportPollingAgent : IWellmedResultExportPollingAgent
    {
        private readonly IWellmedResultExportService _wellmedResultExportService;

        public WellmedResultExportPollingAgent(IWellmedResultExportService wellmedResultExportService)
        {
            _wellmedResultExportService = wellmedResultExportService;
        }

        public void PollForResultExport()
        {
            _wellmedResultExportService.ResultExport();

        }
    }
}