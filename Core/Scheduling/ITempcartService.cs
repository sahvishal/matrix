using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface ITempcartService
    {
        OnlineRequestValidationModel ValidateOnlineRequest(string guid);
        void SaveTempCart(TempCart cart);
        void UpdateTempCartExitPage(string guid, TempCart tempCart);

    }
}
