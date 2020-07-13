using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IMemberUploadByAcesHelper
    {
        CorporateUpload UploadFailedFile(string sourceFile, CorporateUpload corporateUpload);
        CorporateUpload SaveCorporateUpload(CorporateUpload corporateUpload);
        CorporateUpload UploadAdjustOrderFile(string sourceFile, CorporateUpload corporateUpload);
        CorporateUpload Upload(string sourceFile, CorporateAccount account);
        CorporateUpload UpdateCorporateUpload(CorporateUpload corporateUpload, int failedCount, int totalCustomers);
    }
}