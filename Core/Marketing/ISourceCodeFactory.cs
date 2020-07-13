using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Marketing
{
    public interface ISourceCodeFactory
    {
        SourceCodeListModel Create(IEnumerable<SourceCode> sourceCodes, IEnumerable<Package> packages, IEnumerable<Test> tests, IEnumerable<ShippingOption> shippingOptions, IEnumerable<Product> products);
    }
}