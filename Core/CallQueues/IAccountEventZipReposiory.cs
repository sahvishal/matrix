using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues
{
    public interface IAccountEventZipReposiory
    {
        void Delete(long accountId);
        void Save(long accountId, IEnumerable<long> zipIds);

        void DeleteFromSubstitute(long accountId);
        void SaveSubstitute(long accountId, IEnumerable<long> zipIds);
    }
}