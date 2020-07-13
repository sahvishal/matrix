using System.Collections.Generic;
using Falcon.App.Core.ACL.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.ACL.Domain
{
    public class RoleScopeOption
    {
        public Role Role { get; set; }
        public DataScope Scope { get; set; }

        public Dictionary<string, long> KeyCollection()
        {
            var keys = new Dictionary<string, long>
            {
                {Role.GetType().FullName, Role.Id},
                {Scope.GetType().FullName, (long)Scope}
            };

            return keys;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var t = obj as RoleScopeOption;

            if (t == null)
                return false;

            return Role.Id == t.Role.Id && (long)Scope == (long)t.Scope;
        }

        public override int GetHashCode()
        {
            if (Role != null && (long)Scope > 0)
                return (Role.Id + "|" + (long)Scope).GetHashCode();

            return base.GetHashCode();
        }
    }
}