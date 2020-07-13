using System;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.CallQueues
{
    public interface IHealthPlanCustomerExportService
    {
        void HealthPlanIncorrectPhoneCustomerExport(DateTime cutOffDate, string destinationFileFormate, ILogger logger);
        void HealthPlanHomeVisitRequestedCustomerExport(DateTime cutOffDate, string destinationFileFormate, ILogger logger);
        void AnthemHomeVisitRequestedCustomerExport(HealthPlanCustomerExportFilter filter, string destinationFolderPath, string fileName, ILogger logger);

        void AnthemIncorrectPhoneNumbreCustomerExport(HealthPlanCustomerExportFilter filter, string destinationFolderPath, string fileName, ILogger logger);
        void ExcellusMedicaidHomeVisitRequestedCustomerExport(HealthPlanCustomerExportFilter filter, string destinationFolderPath, string fileName, ILogger logger);
        void ExcellusMedicaidIncorrectPhoneCustomerExport(HealthPlanCustomerIncorrectPhoneExportFilter filter, string destinationFolderPath, string fileName, ILogger logger);
    }
}