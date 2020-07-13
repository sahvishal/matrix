using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class BcbsMiMemberResultMailedReportListModel : ListModelBase<BcbsMiMemberResultMailedReportViewModel, MemberResultMailedReportFilter>
    {

        public override System.Collections.Generic.IEnumerable<BcbsMiMemberResultMailedReportViewModel> Collection
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