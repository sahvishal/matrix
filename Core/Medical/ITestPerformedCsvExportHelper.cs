using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ITestPerformedCsvExportHelper
    {
        string WriteCsvTestPerformed(string physicalPath, string fileName, IEnumerable<TestPerformedViewModel> modelData, long userId = 0, ILogger logger = null, bool downloadAsZIP = false);
    }
}
