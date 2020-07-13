using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface IUserNpiInfoRepository
    {
        UserNpiInfo Get(long userId);
        void Save(UserNpiInfo userNpiInfo);
        bool IsNpiExist(string npi, long userId);
        bool IsCredentialExist(string credential, long userId);
        IEnumerable<UserNpiInfo> GetByUserIds(IEnumerable<long> userIds);
    }
}
