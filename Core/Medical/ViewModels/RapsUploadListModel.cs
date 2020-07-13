using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class RapsUploadListModel : ListModelBase<RapsUploadModel, RapsUploadListModelFilter>
    {
        public override IEnumerable<RapsUploadModel> Collection { get; set; }
        public override RapsUploadListModelFilter Filter { get; set; }
        public string Url { get; set; }
    }
}
