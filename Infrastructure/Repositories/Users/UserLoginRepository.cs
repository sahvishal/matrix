using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Factories.Users;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.Linq;
using Falcon.Data.HelperClasses;

namespace Falcon.App.Infrastructure.Repositories.Users
{
    public class UserLoginRepository : PersistenceRepository, IUserLoginRepository
    {
        private readonly IUserLoginFactory _userLoginFactory;
        private readonly IOneWayHashingService _oneWayHashingService;
        const long sysAdminId = 1;

        private readonly PasswordCryptographyService _cryptographyService = new PasswordCryptographyService();

        public UserLoginRepository(IOneWayHashingService oneWayHashingService)
        {
            _oneWayHashingService = oneWayHashingService;
            _userLoginFactory = new UserLoginFactory(_oneWayHashingService);
        }

        public UserLoginRepository(IPersistenceLayer persistenceLayer, IUserLoginFactory userLoginFactory, IOneWayHashingService oneWayHashingService)
            : base(persistenceLayer)
        {
            _oneWayHashingService = oneWayHashingService;

            _userLoginFactory = userLoginFactory;
        }

        public UserLogin GetByUserName(string userName)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var userLogin = linqMetaData.UserLogin.SingleOrDefault(ul => ul.UserName == userName);
                if (userLogin == null)
                    throw new ObjectNotFoundInPersistenceException<UserLogin>();
                return _userLoginFactory.CreateUserLogin(userLogin);
            }
        }

        public UserLogin GetByUserId(long userId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var userLogin = linqMetaData.UserLogin.SingleOrDefault(ul => ul.UserLoginId == userId);
                if (userLogin == null)
                    throw new ObjectNotFoundInPersistenceException<UserLogin>();
                return _userLoginFactory.CreateUserLogin(userLogin);
            }
        }

        public bool UniqueUserName(long userLoginId, string userName)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return !linqMetaData.UserLogin.Any(u => u.UserLoginId != userLoginId && u.UserName == userName);
            }
        }

        public UserLogin SaveUserLogin(UserLogin userLogin, long userId)
        {
            if (userLogin == null)
            {
                throw new ArgumentNullException("userLogin", "The given userLogin cannot be null.");
            }
            var userLoginEntity = _userLoginFactory.CreateUserLoginEntity(userLogin, userId);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.SaveEntity(userLoginEntity, true))
                {
                    throw new PersistenceFailureException();
                }
                userLogin.Id = userLoginEntity.UserLoginId;
                return userLogin;
            }
        }

        public UserLogin UpdateLoginStatus(long userLoginId, bool isSuccessfulLogin)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var userLoginEntity = new UserLoginEntity(userLoginId);
                if (myAdapter.FetchEntity(userLoginEntity))
                {
                    userLoginEntity.IsNew = false;
                    userLoginEntity.LoginAttempts = isSuccessfulLogin ? 0 : ++userLoginEntity.LoginAttempts;
                    userLoginEntity.IsLocked = isSuccessfulLogin
                                                   ? false
                                                   : userLoginEntity.LoginAttempts >= 5;

                    userLoginEntity.LastLoginAttemptAt = isSuccessfulLogin ? null : (DateTime?)DateTime.Now;
                    userLoginEntity.LastLogged = isSuccessfulLogin ? DateTime.Now : userLoginEntity.LastLogged;
                    myAdapter.SaveEntity(userLoginEntity, true);
                    return _userLoginFactory.CreateUserLogin(userLoginEntity);
                }
                return null;
            }
        }

        public SecureHash ResetPassword(long userLoginId, string password, bool userVerified = true)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var userLoginEntity = new UserLoginEntity(userLoginId);

                if (myAdapter.FetchEntity(userLoginEntity))
                {
                    userLoginEntity.IsNew = false;
                    var securehash = _oneWayHashingService.CreateHash(password);
                    userLoginEntity.Password = securehash.HashedText;
                    userLoginEntity.Salt = securehash.Salt;

                    userLoginEntity.UserVerified = userVerified;
                    userLoginEntity.LastPasswordChangeDate = DateTime.Now;
                    if (userVerified)
                        userLoginEntity.ResetPwdQueryString = null;
                    myAdapter.SaveEntity(userLoginEntity, true);
                    return securehash;
                }
                return null;
            }
        }

        public SecureHash ForceChangePassword(long userLoginId, string password, bool forceChangePassword)
        {

            var userLoginEntity = new UserLoginEntity(userLoginId);
            var securehash = _oneWayHashingService.CreateHash(password);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (myAdapter.FetchEntity(userLoginEntity))
                {
                    userLoginEntity.IsNew = false;

                    userLoginEntity.Password = securehash.HashedText;
                    userLoginEntity.Salt = securehash.Salt;
                    userLoginEntity.UserVerified = forceChangePassword ? false : true;
                    userLoginEntity.LastPasswordChangeDate = DateTime.Now;
                    myAdapter.SaveEntity(userLoginEntity, false);
                    return securehash;
                }
            }
            return null;
        }


        public bool SaveSecurityQuestionAnswer(long userLoginId, string question, string answer)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var userLoginEntity = new UserLoginEntity(userLoginId);

                if (myAdapter.FetchEntity(userLoginEntity))
                {
                    userLoginEntity.IsNew = false;
                    userLoginEntity.HintQuestion = question;
                    userLoginEntity.HintAnswer = _cryptographyService.Encrypt(answer);
                    userLoginEntity.IsSecurityQuestionVerified = true;
                    myAdapter.SaveEntity(userLoginEntity, true);
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// By Sandeep: 22nd Feb, 2010
        /// Purpose is just to Clear The login attemps along with Releasing the lock.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool ReleaseUserLoginLock(long userId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var userLoginEntity = new UserLoginEntity(userId) { IsLocked = false, LastLoginAttemptAt = null, LoginAttempts = 0 };

                var bucket = new RelationPredicateBucket(UserLoginFields.UserLoginId == userId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(userLoginEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }


        public Boolean ValidateUser(string userName, string password)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var linqMetaData = new LinqMetaData(adapter);
                var userLogin = linqMetaData.UserLogin.Where(u => u.UserName == userName && u.IsActive).SingleOrDefault();

                if (userLogin == null) return false;

                if (userLogin.IsLocked) // The 1 Hour Locking period check
                {
                    if (userLogin.LastLoginAttemptAt == null) return false;
                    if (userLogin.LastLoginAttemptAt.Value.AddHours(1) > DateTime.Now) return false;
                }

                if (userLogin.LastLoginAttemptAt != null && userLogin.LastLoginAttemptAt.Value.AddHours(1) < DateTime.Now) // Recycling data if login attempt was an hour back
                {
                    userLogin.IsLocked = false;
                    userLogin.LastLoginAttemptAt = null;
                    userLogin.LoginAttempts = 0;
                    adapter.SaveEntity(userLogin, true);
                }

                return _oneWayHashingService.Validate(password, new SecureHash(userLogin.Password, userLogin.Salt));
            }
        }


        //TODO: Mostly NITIN put this here. JERK! Need to remove it. - Yasir (April 2011)
        private Boolean IsPrintVendor(string userName)
        {

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);


                return linqMetaData.UserLogin.
                        Join(linqMetaData.User, ul => ul.UserLoginId, u => u.UserId, (ul, u) => new { ul, u }).
                        Join(linqMetaData.OrganizationRoleUser, @a => @a.u.UserId, oru => oru.UserId, (@a, oru) => new { @a, oru }).
                        Join(linqMetaData.Role, @b => @b.oru.RoleId, r => r.RoleId, (@b, r) => new { @b, r })
                        .Where(@c => @c.b.a.ul.UserName == userName && (@c.r.RoleId == (long)Roles.PrintVendorAdmin || @c.r.ParentId == (long)Roles.PrintVendorAdmin)).Select(@c => new { @c.r }).Any();



            }
        }

        public string[] GetRolesForUser(string username)
        {
            var roles = new List<string>();

            if (IsPrintVendor(username))
            {
                roles.Add("PrintVendor");
            }

            return roles.ToArray();
        }

        public bool UpdateUserName(long userLoginId, string userName)
        {
            using (IDataAccessAdapter adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var userLoginEntity = new UserLoginEntity(userLoginId) { UserName = userName };
                var bucket = new RelationPredicateBucket(UserLoginFields.UserLoginId == userLoginId);
                try
                {
                    return (adapter.UpdateEntitiesDirectly(userLoginEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public bool UpdateUserLoginIsActiveStatus(long userLoginId, bool isActive)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var userLoginEntity = new UserLoginEntity(userLoginId) { IsActive = isActive };
                var bucket = new RelationPredicateBucket(UserLoginFields.UserLoginId == userLoginId);
                try
                {
                    return (adapter.UpdateEntitiesDirectly(userLoginEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public bool UpdateResetPasswordQueryString(long userLoginId, string resetPasswordQueryString)
        {
            using (IDataAccessAdapter adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var userLoginEntity = new UserLoginEntity(userLoginId) { ResetPwdQueryString = resetPasswordQueryString, UserVerified = false };
                var bucket = new RelationPredicateBucket(UserLoginFields.UserLoginId == userLoginId);
                try
                {
                    return (adapter.UpdateEntitiesDirectly(userLoginEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public bool ForceUserToChangePassword(long userId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var userLoginEntity = new UserLoginEntity(userId) { UserVerified = false };

                var bucket = new RelationPredicateBucket(UserLoginFields.UserLoginId == userId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(userLoginEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public bool ForceUserToChangeQuestion(long userId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var userLoginEntity = new UserLoginEntity(userId) { IsSecurityQuestionVerified = false };

                var bucket = new RelationPredicateBucket(UserLoginFields.UserLoginId == userId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(userLoginEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public bool IsPasswordExpired(string userName, int daysInExpire)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var userLogin = linqMetaData.UserLogin.SingleOrDefault(u => u.UserName == userName && u.IsActive);

                if (userLogin == null) return false;

                if (userLogin.LastPasswordChangeDate.AddDays(daysInExpire).Date < DateTime.Today.Date) return true;

                return false;
            }
        }

        public bool AssignUserLoginLock(long userId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var userLoginEntity = new UserLoginEntity(userId) { IsLocked = true, LastLoginAttemptAt = DateTime.Now, LoginAttempts = 1 };

                var bucket = new RelationPredicateBucket(UserLoginFields.UserLoginId == userId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(userLoginEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public bool IsUserLocked(long userId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var userLogin = linqMetaData.UserLogin.SingleOrDefault(u => u.UserLoginId == userId && u.IsActive);

                return userLogin != null && userLogin.IsLocked;
            }
        }

        public double PasswordWillExpiredInDays(string userName, int daysInExpire)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var userLogin = linqMetaData.UserLogin.SingleOrDefault(u => u.UserName == userName && u.IsActive);

                if (userLogin == null) return 0;

                var totalDaysLastPasswordChage = (userLogin.LastPasswordChangeDate.AddDays(daysInExpire).Date - DateTime.Today.Date).TotalDays + 1;

                return totalDaysLastPasswordChage;
            }
        }

        public IEnumerable<UserLogin> GetUsersNotLoggedInWithinDays(int numberOfDays)
        {

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                long[] roleIds = { (long)Roles.Customer, (long)Roles.CorporateAccountCoordinator, (long)Roles.Coder, (long)Roles.NursePractitioner };

                var rolesShouldNotDisabled = (from oru in linqMetaData.OrganizationRoleUser where roleIds.Contains(oru.RoleId) select oru.UserId).Distinct();

                var entities = (from ul in linqMetaData.UserLogin
                                join oru in linqMetaData.OrganizationRoleUser on ul.UserLoginId equals oru.UserId
                                where !rolesShouldNotDisabled.Contains(oru.UserId) && oru.UserId != sysAdminId
                                && ((ul.LastLogged == null && ul.DateCreated < DateTime.Today.AddDays(-1 * numberOfDays)) || ul.LastLogged < DateTime.Today.AddDays(-1 * numberOfDays))
                                && ul.IsActive && !ul.IsLocked
                                select ul).ToArray();

                return entities.Select(userLoginEntity => _userLoginFactory.CreateUserLogin(userLoginEntity)).ToList();
            }
        }

        public MedicareUserCredentialModel[] GetUserForMedicareSync(DateTime exportFromTime)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from ul in linqMetaData.UserLogin
                                where (ul.DateCreated > exportFromTime || ul.DateModified > exportFromTime || ul.LastPasswordChangeDate >= DateTime.Today)
                                && ul.IsActive
                                select new MedicareUserCredentialModel
                                {
                                    Id = ul.UserLoginId,
                                    Password = ul.Password,
                                    Salt = ul.Salt
                                }).ToArray();

                return entities;
            }
        }
    }
}