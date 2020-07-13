using System.Collections.Generic;
using Falcon.App.Core.ACL.Enum;

namespace Falcon.App.Core.ACL.Domain
{
    public class AccessObjectScopeOption
    {
        public  AccessControlObject AccessControlObject { get; set; }
        public DataScope Scope { get; set; }

        public Dictionary<string, long> KeyCollection()
        {
            var keys = new Dictionary<string, long>
            {
                {AccessControlObject.GetType().FullName, AccessControlObject.Id},
                {Scope.GetType().FullName, (long)Scope}
            };

            return keys;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var t = obj as AccessObjectScopeOption;

            if (t == null)
                return false;

            return AccessControlObject.Id == t.AccessControlObject.Id && (long)Scope == (long)t.Scope;
        }

        public override int GetHashCode()
        {
            if (AccessControlObject != null && (long)Scope > 0)
                return (AccessControlObject.Id + "|" + (long)Scope).GetHashCode();

            return base.GetHashCode();
        }
    }
}