using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.ACL.ViewModel
{
    [NoValidationRequired]
    public class AccessControlObjectViewModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Alias { get; set; }

        public bool IsSelected { get; set; }

        public bool IsRequired { get; set; }

        //public bool? IsAvailableInParent { get; set; }

        public long DataScopeId { get; set; }

        public IEnumerable<long> DataScopeOptions { get; set; }

        public int? DisplayOrder { get; set; }

        public IList<AccessControlObjectViewModel> Children { get; set; }

        public bool IsRootParent { get; set; }

        public AccessControlObjectViewModel()
        {
            Children = new List<AccessControlObjectViewModel>();
        }

    }
}