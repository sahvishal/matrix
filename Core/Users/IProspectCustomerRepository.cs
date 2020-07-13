using System;
using System.Collections.Generic;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IProspectCustomerRepository
    {
        ProspectCustomer GetProspectCustomer(long prospectCustomerId);
        List<ProspectCustomer> GetProspectCustomers(long[] prospectCustomerIds);
        bool IsConvertedandRegistered(long prospectCustomerId, long eventId);        
        bool UpdateProspectCustomerConversionState(ProspectCustomerConversionStatus conversionStatus, long prospectCustomerId);
        List<ProspectCustomerViewData> GetProspectCustomersForSalesRep(DateTime? startDate, DateTime? endDate,
                                                                          string prospectName,long eventId, string SourceCode,string welnessSeminarName,
                                                                          ProspectCustomerConversionStatus?
                                                                              prospectCustomerConversionStatus,
                                                                          long salesRepId, int pageNumber,
                                                                          int pageSize, out long totalRecord);
        List<ProspectCustomerViewData> GetProspectCustomersWithFiltersforCallCenterRep(string firstname, string lastName, string callBackNumber);
        bool IsProspectAWorkshopProspect(long prospectCustomerId);
        IList<ProspectCustomer> GetProspectCustomersAfter(DateTime lastChecked);

        IEnumerable<ProspectCustomer> GetAbandonedProspectCustomer(int pageNumber, int pageSize,
                                                                   ProspectCustomerListModelFilter filter, out int totalRecords);

        bool Delete(long prospectCustomerId);
        bool Delete(long[] prospectCustomerIds);
        ProspectCustomer GetProspectCustomerByCustomerId(long customerId);
        bool UpdateContactedStatus(long prospectCustomerId, long contactedBy);
        bool UpdateDoNotCallStatus(long prospectCustomerId, ProspectCustomerConversionStatus status);
        ProspectCustomer GetProspectCustomermatchingConditions(string firstName, string lastName, string email, string phoneNumber);
        IEnumerable<ProspectCustomer> GetProspectCustomersForReminder(int days);
        IEnumerable<OrderedPair<long, long?>> GetProspectsBasedOnGeography(string zipCode, int radius, string searchTag);
        IEnumerable<OrderedPair<long, long?>> GetEasiestToConvertProspect(DateTime? lastGeneratedDate);

        IEnumerable<FillEventProspectCustomerViewModel> GetProspectCustomerForFillEventCallQueue(
            List<OrderedPair<long, string>> eventIdZips, List<OrderedPair<string, string>> zipZipStringPairList);
        IEnumerable<ProspectCustomer> GetCallBackQueue(DateTime? lastGeneratedDate);

        List<ProspectCustomer> GetProspectCustomersByCustomerIds(long[] customerIds);
        IEnumerable<long> GetCustomerIdsByTag(ProspectCustomerTag tag, CallStatus status);

        IEnumerable<ProspectCustomer> GetForInterviewReport(InterviewInboundFilter filter);
    }
}