using System.ComponentModel;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class EventCdContentStatusViewModel
    {
        public long EventId { get; set; }
        public int Generated { get; set; }
        [DisplayName("In Queue")]
        public int InQueue { get; set; }
        [DisplayName("Result Not Generated")]
        public int ResultNotGenerated { get; set; }
    }
}
