using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorEarningRepository
    {
        List<MedicalVendorEarning> GetEarningsForMedicalVendorUser(long organizationRoleUserId, 
            DateTime payPeriodStartDate, DateTime payPeriodEndDate);
        bool CustomerEventTestIdHasEarnings(long customerEventTestId);
        OrderedPair<int, decimal> GetNumberOfEarningsAndTotalAmountEarnedForUser(long organizationRoleUserId);
        OrderedPair<int, decimal> GetNumberOfEarningsAndTotalAmountEarnedForUser(long organizationRoleUserId, DateTime startDate, 
            DateTime endDate);
        void SaveMedicalVendorEarning(MedicalVendorEarning medicalVendorEarning);
        int GetEarningsNotInDateRanges(long organizationRoleUserId, List<OrderedPair<DateTime, DateTime>> dateRanges);
    }
}