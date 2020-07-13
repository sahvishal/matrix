using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
  public  interface IKynCustomerReportService
  {
      ListModelBase<KynCustomerModel, KynCustomerModelFilter> GetKynCustomerReport(int pageNumber, int pageSize,ModelFilterBase filter, out int totalRecords);
  }
}
