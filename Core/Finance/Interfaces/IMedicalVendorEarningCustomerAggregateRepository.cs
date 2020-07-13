using System;
using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorEarningCustomerAggregateRepository
    {
        List<MedicalVendorEarningCustomerAggregate> GetEarningCustomerAggregatesNotInDateRanges
            (long organizationRoleUserId, List<OrderedPair<DateTime, DateTime>> dateRanges);

        List<MedicalVendorEarningCustomerAggregate> GetEarningCustomerAggregates(long organizationRoleUserId,
            DateTime startDate, DateTime endDate, int pageNumber, int pageSize);
        int GetNumberofEarningCustomerAggregates(long organizationRoleUserId, DateTime startDate, DateTime endDate);
        
        List<MedicalVendorEarningCustomerAggregate> GetEarningCustomerAggregatesForVendor(long medicalVendorId, 
            DateTime startDate, DateTime endDate, int pageNumber, int pageSize);
        int GetNumberOfEarningCustomerAggregatesForVendor(long medicalVendorId, DateTime startDate, DateTime endDate);
    }
}