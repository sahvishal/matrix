using System.Collections.Generic;
using System.Data;
using Falcon.App.Core;
using Falcon.App.Core.Finance.Domain;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Finance.Interfaces
{
    public interface IMedicalVendorInvoiceStatisticFactory
    {
        List<MedicalVendorInvoiceStatistic> CreateMedicalVendorInvoiceStatistics(IEnumerable<PhysicianInvoiceEntity> 
            medicalVendorInvoiceEntities, DataTable medicalVendorInvoiceItemStatistics);
        MedicalVendorInvoiceStatistic CreateMedicalVendorInvoiceStatistic(PhysicianInvoiceEntity medicalVendorInvoiceEntity,
            DataRow invoiceItemStatisticsForInvoice);
        OrderedPair<ResultsetFields, GroupByCollection> CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClause();
    }
}