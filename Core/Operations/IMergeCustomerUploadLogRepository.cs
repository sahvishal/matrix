using System;
using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface IMergeCustomerUploadLogRepository
    {
        bool MergeCustomer(long oldCustomerId, long newCustomerId, long orgRoleId);
        bool DeleteRaps(long oldCustomerId);
        bool UpdateCustomerBillingInfo(long oldCustomerId, long newCustomerId);
        bool DeleteCustomerBilllingAccount(long oldCustomerId, long oldBillingAccountId);
        bool DeleteCustomerPredictedZip(long customerId, DateTime startDate, DateTime endDate);
        bool UpdatePredictedZip(long oldCustomerId, long newCustomerId);
        bool DeleteDuplicateCustomerTag(long oldCustomerId, IEnumerable<string> tag);
        bool DeleteOrderDetails(long eventCustomerId);

        MergeCustomerUploadLog Save(MergeCustomerUploadLog domain);
        IEnumerable<MergeCustomerUploadLog> GetUploadLogsForMerge(long uploadId);
        IEnumerable<MergeCustomerUploadLog> GetFailedCustomers(long uploadId);
        long GetSuccessfulCustomersCount(long uploadId);
        bool DeleteCustomer(long customerId);
        bool UpdateCustomerRaps(long oldCustomerId, long newCustomerId);
        bool DeleteCustomerResultPosted(long oldCustomerId);
        bool UpdateCustomerResultPosted(long oldCustomerId, long newCustomerId);

        bool DeleteCustomerEligibility(long oldCustomerId, int forYear);
        bool UpdateCustomerEligibility(long oldCustomerId, long newCustomerId);

        bool DeleteCustomerTargeted(long oldCustomerId, int forYear);
        bool UpdateCustomerTargeted(long oldCustomerId, long newCustomerId);

        bool DeleteCustomerTrale(long oldCustomerId);
        bool UpdateCustomerTrale(long oldCustomerId, long newCustomerId);

        bool DeleteCareCodeingOutbound(long oldCustomerId);
        bool UpdateCareCodingOutbound(long oldCustomerId, long newCustomerId);

        bool DeleteCustomerUnsubscribed(long oldCustomerId);
        bool UpdateCustomerUnsubscribed(long oldCustomerId, long newCustomerId);

        bool UpdateSuspectCondition(long oldCustomerId, long newCustomerId);
        bool DeleteSuspectCondition(long oldCustomerId, IEnumerable<long> suspectId);

        bool UpdateMedication(long oldCustomerId, long newCustomerId);
        bool DeleteMedication(long oldCustomerId, IEnumerable<long> medicationId);

        bool UpdateCustomerProfileHistory(long mergedCustomerId, long customerProfileHistoryId);

        bool DeleteCustomerWarmTransfer(long oldCustomerId, int forYear);
        bool UpdateCustomerWarmTransfer(long oldCustomerId, long newCustomerId);

        bool UpdateMemberUploadLog(long oldCustomerId, long newCustomerId);
        bool UpdateEventCustomerQuestionAnswer(long oldCustomerId, long newCustomerId);

        bool UpdateCustomerClinicalQuestionAnswer(long oldCustomerId, long newCustomerId);
    }
}
