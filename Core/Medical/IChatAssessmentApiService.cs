
namespace Falcon.App.Core.Medical
{
    public interface IChatAssessmentApiService
    {
        T Post<T>(object data);
        //T Get<T>(string url);
    }
}
