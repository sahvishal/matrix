using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class MemberResultMailedReportListModel : ListModelBase<MemberResultMailedReportViewModel, MemberResultMailedReportFilter>
    {

        public override System.Collections.Generic.IEnumerable<MemberResultMailedReportViewModel> Collection
        {
            get;
            set;
        }

        public override MemberResultMailedReportFilter Filter
        {
            get;
            set;
        }
    }
}