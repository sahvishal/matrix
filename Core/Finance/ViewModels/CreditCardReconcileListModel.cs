using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CreditCardReconcileListModel : ListModelBase<CreditCardReconcileModel, CreditCardReconcileModelFilter>
    {
        public override IEnumerable<CreditCardReconcileModel> Collection { get; set; }
        public override CreditCardReconcileModelFilter Filter { get; set; }
    }
}