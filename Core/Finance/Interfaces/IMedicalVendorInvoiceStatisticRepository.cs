using System;
using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorInvoiceStatisticRepository
    {
        MedicalVendorInvoiceStatistic GetInvoiceStatistic(long medicalVendorInvoiceId);
        List<MedicalVendorInvoiceStatistic> GetAllInvoiceStatistics();
        List<MedicalVendorInvoiceStatistic> GetInvoiceStatisticsByPaymentStatus(PaymentStatus paymentStatus);
        List<MedicalVendorInvoiceStatistic> GetInvoiceStatisticsForMedicalVendorUser(long medicalVendorUserId, PaymentStatus paymentStatus);
        List<MedicalVendorInvoiceStatistic> GetInvoiceStatisticsForMedicalVendorUser(long organizationRoleUserId, DateTime startDate, 
            DateTime endDate, int pageNumber, int pageSize);
        List<MedicalVendorInvoiceStatistic> GetInvoiceStatisticsForMedicalVendor(long medicalVendorId, DateTime startDate, 
            DateTime endDate, int pageNumber, int pageSize);

        int GetNumberOfInvoiceStatisticsForMedicalVendorUser(long organizationRoleUserId, DateTime startDate, DateTime endDate);
        int GetNumberOfInvoiceStatisticsForMedicalVendor(long medicalVendorId, DateTime startDate, DateTime endDate);
    }
}