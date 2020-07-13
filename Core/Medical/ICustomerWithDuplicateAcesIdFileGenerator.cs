using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface ICustomerWithDuplicateAcesIdFileGenerator
    {
        void GenerateCsvFile(long corporateUploadId, IEnumerable<CustomerWithDuplicateAcesModel> customers);
    }
}
