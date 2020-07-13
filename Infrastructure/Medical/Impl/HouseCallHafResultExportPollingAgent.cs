using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class HouseCallHafResultExportPollingAgent : IHouseCallHafResultExportPollingAgent
    {
        private readonly IHouseCallHafResultExportService _houseCallHafResultExportService;

        public HouseCallHafResultExportPollingAgent(IHouseCallHafResultExportService houseCallHafResultExportService)
        {
            _houseCallHafResultExportService = houseCallHafResultExportService;
        }

        public void PollForResultExport()
        {
            _houseCallHafResultExportService.ResultExport();
        }
    }
}
