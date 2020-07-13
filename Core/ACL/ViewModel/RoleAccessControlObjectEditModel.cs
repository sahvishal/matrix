using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.ACL.ViewModel
{
    [NoValidationRequired]
    public class RoleAccessControlObjectEditModel : ViewModelBase
    {
        public long RoleId { get; set; }

        public string RoleName { get; set; }

        public IList<AccessControlObjectViewModel> AccessControlObjects { get; set; }

        public RoleAccessControlObjectEditModel()
        {
            AccessControlObjects = new List<AccessControlObjectViewModel>();
        }
    }
}