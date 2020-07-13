using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class BiWeeklyMicroAlbuminFobtReportListModel : ListModelBase<BiWeeklyMicroAlbuminFobtReportViewModel, BiWeeklyMicroAlbuminFobtReportModelFilter>
    {
        public override IEnumerable<BiWeeklyMicroAlbuminFobtReportViewModel> Collection { get; set; }

        public override BiWeeklyMicroAlbuminFobtReportModelFilter Filter { get; set; }
    }
}