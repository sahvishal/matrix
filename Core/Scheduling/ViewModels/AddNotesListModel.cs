using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class AddNotesListModel : ListModelBase<AddNotesViewModel, AddNotesModelFilter>
    {
        public override IEnumerable<AddNotesViewModel> Collection { get; set; }

        public override AddNotesModelFilter Filter { get; set; }

        public string EventIds { get; set; }

        public string Note { get; set; }

        public bool IsPublish { get; set; }

        public bool AllSelected { get; set; }

        public long TotalRecords { get; set; }

        public bool IsSavedSuccessfully { get; set; }
    }
}
