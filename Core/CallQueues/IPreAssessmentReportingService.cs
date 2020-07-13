using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallQueues
{
   public interface IPreAssessmentReportingService
    {
       ListModelBase<PreAssessmentReportViewModel, PreAssessmentReportFilter> GetPreAssessmentReport(int pageNumber, int pageSize, ModelFilterBase filter, out int totalRecords);
    }
}
