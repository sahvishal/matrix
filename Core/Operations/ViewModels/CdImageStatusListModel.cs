using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class CdImageStatusListModel : ListModelBase<CdImageStatusModel, CdImageStatusModelFilter>
    {
        public override IEnumerable<CdImageStatusModel> Collection { get; set; }
        public override CdImageStatusModelFilter Filter { get; set; }
    }
}