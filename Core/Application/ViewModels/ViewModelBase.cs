using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Application.ViewModels
{
    public abstract class ViewModelBase
    {
        [IgnoreAudit]
        public FeedbackMessageModel FeedbackMessage { get; set; }
         
    }
}