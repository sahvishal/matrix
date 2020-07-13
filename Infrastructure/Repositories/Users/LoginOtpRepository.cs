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
    public class LoginOtpRepository : PersistenceRepository, ILoginOtpRepository
    {
        public LoginOtp Get(long userLoginId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (userLoginId > 0)
                {
                    var list = (from c in linqMetaData.LoginOtp where c.UserLoginId == userLoginId select c).FirstOrDefault();
                    return list == null ? null : Mapper.Map<LoginOtpEntity, LoginOtp>(list);
                }
                return null;
            }
        }
        public bool Save(LoginOtp loginOtp)
        {
            var loginOtpEntity = Mapper.Map<LoginOtp, LoginOtpEntity>(loginOtp);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                loginOtpEntity.IsNew = !myAdapter.FetchEntity(new LoginOtpEntity(loginOtp.UserLoginId)); ;
                if (!myAdapter.SaveEntity(loginOtpEntity, false))
                {
                    throw new PersistenceFailureException();
                }
                return true;
            }
        }
    }
}
