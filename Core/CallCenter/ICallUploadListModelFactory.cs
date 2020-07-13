using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.ViewModels;

namespace Falcon.App.Core.CallCenter
{
    public interface ICallUploadListModelFactory
    {
        CallUploadListModel Create(IEnumerable<FileModel> fileModel, IEnumerable<CallUpload> callUpload, IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair); 
    }
}
