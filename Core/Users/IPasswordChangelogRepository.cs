using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface IPasswordChangelogRepository
    {
        IEnumerable<PasswordChangelog> GetOldPasswordList(long userLoginId);
        bool Save(PasswordChangelog passwordChangelog);
        bool Delete(PasswordChangelog passwordChangelog);
    }
}
