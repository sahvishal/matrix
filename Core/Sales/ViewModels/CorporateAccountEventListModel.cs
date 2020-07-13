using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class CorporateAccountEventListModel : ListModelBase<CorporateAccountEventViewModel, CorporateAccountEventListModelFilter>
    {
        public override IEnumerable<CorporateAccountEventViewModel> Collection { get; set; }
        public override CorporateAccountEventListModelFilter Filter { get; set; }
    }
}