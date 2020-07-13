using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class MedicationUploadListModel : ListModelBase<MedicationUploadViewModel, MedicationUploadListModelFilter>
    {
        public override IEnumerable<MedicationUploadViewModel> Collection { get; set; }
        public override MedicationUploadListModelFilter Filter { get; set; }

        public string Url { get; set; }
    }
}
