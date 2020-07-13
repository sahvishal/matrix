using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Finance.Impl;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CorporateAccountInvoiceListModel : ListModelBase<CorporateAccountInvoiceLineItemViewModel, CorporateAccountInvoiceListModelFilter>
    {
        public override IEnumerable<CorporateAccountInvoiceLineItemViewModel> Collection { get; set; }

        public override CorporateAccountInvoiceListModelFilter Filter { get; set; }


        public static CorporateAccountInvoiceListModel Empty()
        {
            return (CorporateAccountInvoiceListModel)Activator.CreateInstance(typeof(CorporateAccountInvoiceListModel));
        }
    }
}