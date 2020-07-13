using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Users
{
    [DefaultImplementation]
    public class LoginSettingRepository : PersistenceRepository, ILoginSettingRepository
    {
        public LoginSettings Get(long userLoginId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (userLoginId > 0)
                {
                    var list = (from c in linqMetaData.LoginSettings where c.UserLoginId == userLoginId select c).FirstOrDefault();
                    return list == null ? null : Mapper.Map<LoginSettingsEntity, LoginSettings>(list);
                }
                return null;
            }
        }
        public bool Save(LoginSettings loginSettings)
        {
            var loginSettingsEntity = Mapper.Map<LoginSettings, LoginSettingsEntity>(loginSettings);
            using (IDataAccessAdapter adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                loginSettingsEntity.IsNew = !adapter.FetchEntity(new LoginSettingsEntity(loginSettings.UserLoginId));

                if (!adapter.SaveEntity(loginSettingsEntity, false))
                {
                    throw new PersistenceFailureException();
                }
                return true;
            }
        }
    }
}
