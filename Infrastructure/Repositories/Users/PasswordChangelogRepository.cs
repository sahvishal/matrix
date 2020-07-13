using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Users
{
    [DefaultImplementation]
    public class PasswordChangelogRepository : PersistenceRepository, IPasswordChangelogRepository
    {
        public IEnumerable<PasswordChangelog> GetOldPasswordList(long userLoginId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (userLoginId > 0)
                {
                    var list = (from c in linqMetaData.PasswordChangelog where c.UserLoginId == userLoginId select c).ToArray();
                    if (list.IsNullOrEmpty())
                        return null;

                    return Mapper.Map<IEnumerable<PasswordChangelogEntity>, IEnumerable<PasswordChangelog>>(list);
                }
                return null;
            }
        }
        public bool Save(PasswordChangelog passwordChangelog)
        {
            var passwordChangelogEntity = Mapper.Map<PasswordChangelog, PasswordChangelogEntity>(passwordChangelog);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.SaveEntity(passwordChangelogEntity, false))
                {
                    throw new PersistenceFailureException();
                }
                return true;
            }
        }
        public bool Delete(PasswordChangelog passwordChangelog)
        {
            var passwordChangelogEntity = Mapper.Map<PasswordChangelog, PasswordChangelogEntity>(passwordChangelog);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.DeleteEntity(passwordChangelogEntity))
                {
                    throw new PersistenceFailureException();
                }
                return true;
            }
        }
    }
}
