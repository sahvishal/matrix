using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class TextReminderListModel : ListModelBase<TextReminderViewModel, TextReminderModelFilter>
    {
        public override IEnumerable<TextReminderViewModel> Collection { get; set; }
        public override TextReminderModelFilter Filter { get; set; }
    }
}
