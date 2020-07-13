using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.HelperClasses;

namespace Falcon.App.Infrastructure.Repositories.Users
{
    [DefaultImplementation(Interface = typeof(IUserLoginLogRepository))]
    public class UserLoginLogRepository : UniqueItemRepository<UserLoginLog, UserLoginLogEntity>, IUserLoginLogRepository
    {
        public UserLoginLogRepository()
            : this(new UserLoginLogMapper())
        { }

        public UserLoginLogRepository(IMapper<UserLoginLog, UserLoginLogEntity> mapper)
            : base(mapper)
        { }


        protected override EntityField2 EntityIdField
        {
            get { return UserLoginLogFields.UserLoginLogId; }
        }

        public UserLoginLog GetCurrentLoggedInLogforUser(long userId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.UserLoginLog.Where(ul => ul.UserId == userId && !ul.LogoutDatetime.HasValue).OrderByDescending(ul => ul.LoginDatetime).FirstOrDefault();
                if (entity == null) return null;

                return Mapper.Map(entity);
            }
        }

        /// <summary>
        /// If logged out time is not provided, it will update with the current time (DateTime.Now).
        /// </summary>
        /// <param name="loginLogId"></param>
        /// <param name="loggedOutTime"></param>
        /// <returns></returns>
        public void UpdateLogOutTimeforUser(long loginLogId, DateTime? loggedOutTime = null)
        {
            if (loggedOutTime == null)
                loggedOutTime = DateTime.Now;

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                //var loginLogId = linqMetaData.UserLoginLog.Where(ul => ul.UserId == userId && !ul.LogoutDatetime.HasValue).Max(ul => ul.UserLoginLogId);

                if (loginLogId > 0)
                {
                    adapter.UpdateEntitiesDirectly(new UserLoginLogEntity() { LogoutDatetime = loggedOutTime, MedicareToken = null },
                                                   new RelationPredicateBucket(UserLoginLogFields.UserLoginLogId ==
                                                                               loginLogId));
                }
            }
        }

        public DateTime? GetLastLoginTime(long userId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var lastLoginDate = linqMetaData.UserLoginLog.Where(ull => ull.UserId == userId).Max(ull => ull.LoginDatetime);
                return lastLoginDate == default(DateTime) ? null : (DateTime?)lastLoginDate;
            }
        }

        public long GetAuthenticatedUserSessionIdUserId(string sessionId, long userId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var user = linqMetaData.UserLoginLog.OrderByDescending(x => x.LoginDatetime).FirstOrDefault(ull => ull.BrowserSessionId == sessionId && ull.UserId == userId && !ull.LogoutDatetime.HasValue);

                return user == null ? 0 : user.UserId;
            }
        }

        public string GetMedicareToken(long userLoginLogId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.UserLoginLog.FirstOrDefault(ul => ul.UserLoginLogId == userLoginLogId && !ul.LogoutDatetime.HasValue);
                return entity == null ? null : Mapper.Map(entity).MedicareToken;
            }
        }

        //public UserLoginLog GetLatestLoginForMedicare(long userId)
        //{
        //    using (var adapter = PersistenceLayer.GetDataAccessAdapter())
        //    {
        //        var linqMetaData = new LinqMetaData(adapter);

        //        var entity =
        //            linqMetaData.UserLoginLog.OrderByDescending(x => x.UserLoginLogId)
        //                .FirstOrDefault(x => x.UserId == userId && x.LoginDatetime == null);
        //        return Mapper.Map(entity);
        //    }
        //}
    }
}
