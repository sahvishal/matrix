using Falcon.App.Core.Application.Domain;

namespace Falcon.App.Core.Application
{
    public interface IFileMediaRepository
    {
        FileMediaDetail GetDetails(long fileId);
    }
}
