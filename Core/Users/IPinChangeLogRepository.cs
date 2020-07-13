using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface IPinChangeLogRepository
    {
        IEnumerable<PinChangelog> GetOldPinList(long technicianId);
        bool Save(PinChangelog pinChangelog);
        bool Delete(PinChangelog pinChangelog);
    }
}
