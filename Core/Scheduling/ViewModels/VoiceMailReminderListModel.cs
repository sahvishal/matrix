using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class VoiceMailReminderListModel : ListModelBase<VoiceMailReminderModel, VoiceMailReminderModelFilter>
    {
        public override IEnumerable<VoiceMailReminderModel> Collection { get; set; }
        public override VoiceMailReminderModelFilter Filter { get; set; }
    }
}
