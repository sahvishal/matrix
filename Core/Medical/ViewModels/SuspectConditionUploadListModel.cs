using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class SuspectConditionUploadListModel : ListModelBase<SuspectConditionUploadModel, SuspectConditionUploadListModelFilter>
    {
        public override IEnumerable<SuspectConditionUploadModel> Collection { get; set; }
        public override SuspectConditionUploadListModelFilter Filter { get; set; }
        public string Url { get; set; }
    }
}
