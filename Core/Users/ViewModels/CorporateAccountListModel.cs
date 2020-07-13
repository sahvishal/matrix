using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Users.ViewModels
{
    public class CorporateAccountListModel
    {
        public IEnumerable<CorporateAccountModel> CorporateAccounts { get; set; }
        public CorporateAccountListModelFilter Filter { get; set; }

        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }
    }
}


