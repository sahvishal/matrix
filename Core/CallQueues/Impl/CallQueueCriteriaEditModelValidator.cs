using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.CallQueues.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CallQueueCriteriaEditModel>))]
    public class CallQueueCriteriaEditModelValidator : AbstractValidator<CallQueueCriteriaEditModel>
    {
        public CallQueueCriteriaEditModelValidator()
        {
            
        }
    }
}
