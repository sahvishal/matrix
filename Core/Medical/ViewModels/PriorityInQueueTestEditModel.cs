using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class PriorityInQueueTestEditModel : ViewModelBase
    {
        public long CustomerEventScreeningTestId { get; set; }  

        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        public long TestId { get; set; }
    }
}
