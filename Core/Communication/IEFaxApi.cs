using Falcon.App.Core.Communication.ViewModels;

namespace Falcon.App.Core.Communication
{
    public interface IEFaxApi
    {
        EFaxResponse SendCreateEFax(EFaxParmaters parmaters);
        EFaxOutboundResponsStatus GetOutboundStatusResponse(long transmissionId);
    }
}
