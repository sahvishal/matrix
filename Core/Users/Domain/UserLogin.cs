using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Users.Domain
{
    public class UserLogin : DomainObjectBase
    {
        public string UserName { get; set; }
        [IgnoreAudit]
        public string Password { get; set; }
        public bool Locked { get; set; }        
        public long FailedAttempts { get; set; }
        public DateTime? LastLogged { get; set; }
        public bool IsSecurityQuestionVerified { get; set; }
        public bool UserVerified { get; set; }

        public string HintQuestion { get; set; }
        [IgnoreAudit]
        public string HintAnswer { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        [IgnoreAudit]
        public string Salt { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastPasswordChangeDate { get; set; }
        public bool? IsTwoFactorAuthrequired { get; set; }
        public DateTime? LastLoginAttemptAt { get; set; }

        public UserLogin() 
        { }

        public UserLogin(string userName, string password, bool isLocked)
        {
            UserName = userName;
            Password = password;
            Locked = isLocked;
        }

        public UserLogin(long userLoginId) 
            : base(userLoginId) 
        { }
    }
}