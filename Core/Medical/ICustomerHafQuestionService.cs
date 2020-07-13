using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface ICustomerHafQuestionService
    {
        HafModel Get(HafFilter filter);
    }
}
