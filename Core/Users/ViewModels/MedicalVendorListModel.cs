using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class MedicalVendorListModel
    {
        public IEnumerable<MedicalVendorModel> MedicalVendors { get; set; }
        public MedicalVendorListModelFilter Filter { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}
