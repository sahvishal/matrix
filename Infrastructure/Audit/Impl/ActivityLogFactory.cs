using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Audit.ViewModel;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Mongo.Domain;

namespace Falcon.App.Infrastructure.Audit.Impl
{
    [DefaultImplementation]
    public class ActivityLogFactory : IActivityLogFactory
    {
        private readonly IUniqueItemRepository<UserLoginLog> _repositoryUserLoginLog;
        private readonly IUserRepository<User> _repositoryUser;
        private readonly IOrganizationRoleUserRepository _repositoryOrganizationRoleUser;

        public ActivityLogFactory(IUniqueItemRepository<UserLoginLog> repositoryUserLoginLog, IUserRepository<User> repositoryUser, IOrganizationRoleUserRepository repositoryOrganizationRoleUser)
        {
            _repositoryUserLoginLog = repositoryUserLoginLog;
            _repositoryUser = repositoryUser;
            _repositoryOrganizationRoleUser = repositoryOrganizationRoleUser;
        }

        public ActivityLogViewModel CreateViewModel(ActivityLog mongoEntity)
        {
            var userLoginLog = mongoEntity.UserLogId > 0 ? _repositoryUserLoginLog.GetById(mongoEntity.UserLogId) : null;
            return new ActivityLogViewModel
            {
                 LogId = mongoEntity.Id.ToString(),
                 Action = mongoEntity.Action,
                 RequestType = mongoEntity.RequestType,
                 Timestamp = mongoEntity.Timestamp,
                 UrlAccessed = mongoEntity.UrlAccessed,
                 AccessedBy = GetOrganizationRoleUserName(mongoEntity.AccessById),
                 //UrlAlias = GetUrlAlias(mongoEntity.UrlAccessed),
                 UrlAlias = mongoEntity.UrlAccessed,
                 ClientBrowser = userLoginLog !=null ? userLoginLog.BrowserName : string.Empty,
                 ClientIp = userLoginLog != null ? userLoginLog.SessionIP : string.Empty,
                 AccessedById = mongoEntity.AccessById,
                 CustomerId = mongoEntity.CustomerId,
                 Customer = GetOrganizationRoleUserName(mongoEntity.CustomerId)
            };
        }

        private Name GetOrganizationRoleUserName(long orgRoleUserId)
        {
            var name = new Name { FirstName = string.Empty, LastName = string.Empty };

            if (orgRoleUserId <= 0) return name;

            var user = _repositoryOrganizationRoleUser.GetOrganizationRoleUser(orgRoleUserId);
            if (user == null) return name;

            var person = _repositoryUser.GetUser(user.UserId);
            return person != null ? person.Name : name; 
        }

        //private static string GetUrlAlias(string urlAccessed)
        //{
        //    var urlAliases = new List<KeyValuePair<string, string>>()
        //    {
        //        new KeyValuePair<string,string>("/Patients/Profile/Summary","Patient Profile"),
        //        new KeyValuePair<string,string>("/Patients/Profile/DetailView","Patient Profile"),
        //        new KeyValuePair<string,string>("/Patients/Profile/Edit","Patient Profile"),
        //        new KeyValuePair<string,string>("/Patients/Profile/EditModel ","Patient Profile"),
        //    };

        //    return urlAliases.Exists(x => x.Key == urlAccessed)
        //        ? urlAliases.Find(x => x.Key == urlAccessed).Value
        //        : string.Empty;
        //}
    }
}
