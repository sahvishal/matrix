using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Sales
{
    public interface ICustomTagFactory
    {
        IEnumerable<CustomTagViewModel> Create(IEnumerable<CorporateTag> corporateTags, IEnumerable<Organization> organizations, IEnumerable<OrderedPair<string, long>> customerCount);
    }
}
