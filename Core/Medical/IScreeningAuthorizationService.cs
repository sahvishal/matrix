using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IScreeningAuthorizationService
    {
        EventScreeningAuthorizationEditModel GetCustomersForAuthorization(long physicianId);
    }
}
