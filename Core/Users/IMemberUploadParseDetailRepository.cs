using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IMemberUploadParseDetailRepository
    {
        IEnumerable<MemberUploadParseDetail> GetByCorporateUploadId(long corporateUploadId, bool isSuccessful = true);
        void Save(MemberUploadParseDetail domain);
    }
}
