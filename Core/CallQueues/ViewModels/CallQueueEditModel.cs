using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallQueues.ViewModels
{
    public class CallQueueEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long Id { get; set; }

        [DisplayName("Queue Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Attempts")]
        public int Attempts { get; set; }

        [DisplayName("Queue Generation Interval")]
        public int? QueueGenerationInterval { get; set; }

        public IEnumerable<CallQueueCriteriaEditModel> Criterias { get; set; }
        public IEnumerable<CallQueueAssignmentEditModel> Assignments { get; set; }

        public long ScriptId { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Script for Call Center")]
        public string ScriptText { get; set; }

        public CallQueueEditModel()
        {
            Attempts = 1;
        }
    }
}
