using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Application
{
    public interface ITraleApiService
    {
        T Post<T>(object data);
        BioCheckJsonViewModel Post(BioCheckJsonViewModel data);
        T Post<T>(string url, object data);
        T Get<T>(string url);
    }

}
