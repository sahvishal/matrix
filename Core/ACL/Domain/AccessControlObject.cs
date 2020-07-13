using System.Collections.Generic;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.ACL.Domain
{
    public class AccessControlObject : DomainObjectBase
    {
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }

        public AccessControlObject Parent { get; set; }
        public IList<AccessControlObject> Children { get; set; }
        public IList<AccessControlObjectUrl> Urls { get; set; }
        public IList<RoleAccessControlObject> RoleAccessControlObjects { get; set; }

        public IEnumerable<AccessObjectScopeOption> AccessObjectScopeOptions { get; set; }

        public int? DisplayOrder { get; set; }

        public AccessControlObject()
        {
            RoleAccessControlObjects = new List<RoleAccessControlObject>();
            Urls = new List<AccessControlObjectUrl>();
            Children = new List<AccessControlObject>();
        }
    }
}