using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportLeadFactory
    {
        PcpResultExportModel SetLeadData(PcpResultExportModel model, LeadTestResult testResult, IEnumerable<ResultReading<int>> readings, bool useBlankValue = false);
    }
}