using System.Collections.Generic;
using Falcon.App.Core.ACL.Enum; 
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.ACL.Domain
{
    public class RoleAccessControlObject
    {
        public Role Role { get; set; }
        public AccessControlObject AccessControlObject { get; set; }
        public PermissionType PermissionType { get; set; }
        public DataScope DataScope { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var t = obj as RoleAccessControlObject;

            if (t == null)
                return false;

            return Role.Id == t.Role.Id && AccessControlObject.Id == t.AccessControlObject.Id;
        }

        public override int GetHashCode()
        {
            if (Role == null || AccessControlObject == null) return base.GetHashCode();
            return (Role.Id + "|" + AccessControlObject.Id).GetHashCode();
        }

        public Dictionary<string, long> KeyCollection()
        {
            var keys = new Dictionary<string, long>
                {
                    {Role.GetType().FullName, Role.Id},
                    {AccessControlObject.GetType().FullName, AccessControlObject.Id}
                };

            return keys;
        }
    }
}