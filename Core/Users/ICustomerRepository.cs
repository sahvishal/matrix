using System;
using System.Collections.Generic;
using System.Text;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.Users
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(long customerId);
        IEnumerable<long> GetCustomerIdForRaps(string cmsHicn, string firstName, string lastName, DateTime? dob);
        List<Customer> GetCustomers(long[] customerIds);
        Customer GetCustomerByUserId(long userId);
        Customer GetCustomerForShippingDetail(long shippingDetailId);
        long GetCustomerEventCustomerUserId(long customerId);
        bool SaveCustomer(Customer customer);
        bool UniqueEmail(long customerId, string emailAddress);
        bool UpdateMaketingSource(long customerId, string marketingSource);
        Customer GetCustomerByAppointmentId(long appointmentId);
        Customer GetCustomerByOrganizationRoleUser(long organizationRoleUserId);
        List<Customer> GetCustomerByFilters(string firstName, string lastName, long customerId, long stateId,
                                            string cityName, string zipCode, DateTime? registrationDate, string phoneNumber);
        List<Customer> GetCustomersByOrganizationRoleUsers(List<long> organizationRoleUserIds);
        IEnumerable<Customer> GetCustomerForAnnualNotification(DateTime annualDate, int days);
        IEnumerable<Customer> GetCustomerForExport(int pageNumber, int pageSize, CustomerExportListModelFilter filter, out int totalRecords);
        IEnumerable<long> GetCustomerBasedOnGeography(string zipCode, int radius, bool olderThanOneYear);
        IEnumerable<long> GetPhysicianPartnerCustomerBasedOnGeography(string zipCode, int radius, long accountId);
        bool IsCustomerTagInUse(string tag);
        Customer GetCustomerForCorporate(string firstName, string middleName, string lastName, string email, string phoneHome, string phoneCell, DateTime? dob, string tag, StringBuilder filterLevelText);
        bool IsCustomerVerified(AccountVerificationEditModel model);

        IEnumerable<OrderedPair<long, long>> GetCustomerForFillEventCallQueue(
            List<OrderedPair<long, string>> eventIdZips, List<OrderedPair<string, string>> zipZipStringPairList);

        // bool UpdateDoNotCallStatus(long customerId, bool isRevertDoNotCall);

        IEnumerable<long> GetCustomersByHealthPlanForCallRound(string healthPlanTag, int pastAppointmentDays, int roundOfCallCompleted, int lastCallDaysBefore);

        IEnumerable<long> GetCustomersMarkedNoShowForHealthPlanCallQueue(string healthPlanTag, DateTime startDate, DateTime endDate);

        IEnumerable<OrderedPair<long, long>> GetCustomerForHealthPlanFillEventCallQueue(List<EventZipMammoModel> eventZipMammoListModel, string corporateTag, int radius, ILogger logger);

        IEnumerable<long> GetCustomersZipCodeRadiusCallQueue(string healthPlanTag, string zipCode, int radius, int pastAppointmentDays);

        IEnumerable<Customer> GetHealthPlanIncorrectPhoneCustomerExport(HealthPlanCustomerIncorrectPhoneExportFilter filter, int pageNumber, int pageSize, out int totalRecords);

        IEnumerable<Customer> HealthPlanHomeVisitRequestedCustomerExport(HealthPlanCustomerExportFilter filter, int pageNumber, int pageSize, out int totalRecords);

        IEnumerable<long> GetHealthPlanUncontactedCustomers(string healthPlanTag, int neverBeenCalledInDays, int noPastAppointmentInDays);

        IEnumerable<Customer> GetUncontactedCustomers(UncontactedCustomersReportModelFilter filetr, int pageNumber, int pageSize, int neverBeenCalledInDays, int noPastAppointmentInDays, out int totalRecords);

        //bool UpdateIsIncorrectPhoneNumber(long customerId, bool isIncorrectPhoneNumber);

        IEnumerable<long> GetCustomersByHealthPlanForMailRound(string healthPlanTag, string customTags, long campaignId, long criteriaId);

        //bool UpdateIsLanguageBarrier(long customerId, bool isLanguageBarrier);

        IEnumerable<long> GetHealthPlanLanguageBarrierCustomers(string healthPlanTag, int noPastAppointmentInDays);

        IEnumerable<Customer> GetMemberForReport(int pageNumber, int pageSize, MemberStatusListModelFilter filter, out int totalRecords);

        IEnumerable<long> GetCustomerIdByInsuranceId(string insuranceId);

        CorporateAccountMemberStatusViewModel GetMemberStatusForAccountCoordinatorDashboard(long accountId);

        Customer GetCustomerForOutboundImport(string firstName, string middleName, string lastName, string email, string phoneNumber, DateTime? dob, string memberId, string tag);

        IEnumerable<long> GetCustomerForMedicareSync(DateTime fromDate, string tag);

        IEnumerable<long> GetCustomerForMedicareSyncWithoutVisit(DateTime fromDate, string tag);

        IEnumerable<Customer> GetCallQueueExcludedCustomers(CallQueueExcludedCustomerReportModelFilter filter, int pageNumber, int pageSize, out int totalRecords);

        IEnumerable<MedicareEventEditModel> GetEventDetailForMedicareSync(long customerId);

        IEnumerable<MedicareResultEditModel> GetRecentResultUpdatedForMedicareSync(DateTime fromDate, string tag);

        IEnumerable<long> GetEventWithTest(long[] events, string tag, long testId);

        IEnumerable<long> GetCustomersByCustomTag(ResponseVendorReportFilter filter, int pageNumber, int pageSize, out int totalRecords);

        IEnumerable<Customer> GetCustomerWithNoEventsInArea(CustomerWithNoEventsInAreaReportModelFilter filter, int pageNumber, int pageSize, out int totalRecords);

        IEnumerable<ConfirmationQueueCustomerModel> GetHealthPlanConfirmationQueueCustomers(CorporateAccount account);

        Customer GetCustomerForPhoneNumberUpdate(string firstName, string lastName, DateTime dob, string memberId);
        IEnumerable<Customer> GetCustomersByPhoneNumber(string phoneNumber, PhoneNumberType phoneNumberType);
        Customer GetRestrictedCustomer(long customerId, long organizationId);

        IEnumerable<EligibilityUploadCustomerDataViewModel> GetCustomerDataForEligibilityUpload(IEnumerable<long> customerIds);
        IEnumerable<long> GetCustomerIdByHicn(string hicn);
        IEnumerable<OrderedPair<long, DateTime?>> GetCustomerIdDobPair(IEnumerable<long> customerIds);

        void UpdateBillingAddress(long customerId, long addressId);

        IEnumerable<Customer> GetForPcpTrackingReport(int pageNumber, int pageSize, PcpTrackingReportFilter pcpTrackingFilter, out int totalRecords);

        IEnumerable<Customer> GetCustomerForUniversalMemberReport(UniversalMemberListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);

        IEnumerable<long> CheckCustomerExists(long[] customerIds);

        bool UpdateAcesId(long customerId, string acesId);

        IEnumerable<long> CheckCustomerAlreadyHaveAcesId(long[] customerIds);
        IEnumerable<string> CheckAcesIdAlreadyAssignedToCustomer(string[] acesIds);
        IEnumerable<Customer> GetCustomerConsentDataReport(CustomerConsentDataListModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<Customer> GetCustomerForSuspectConditionUpload(string gmpi, string memberId, string memberName, DateTime dob);
        IEnumerable<Customer> GetCustomerForMedicationParsing(string hicn, string memberId, DateTime dob);
        IEnumerable<Customer> GetCustomersWoithoutLoginAndAddressDetails(long[] customerIds);
        List<Customer> GetCustomersByAcesId(string acesId);

        IEnumerable<Customer> GetCustomerForHiptoAcesCrossWalk(HiptoAcesCrossWalkViewModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        List<Customer> GetCustomersByMemberId(string memberId);
        IEnumerable<Customer> GetPatientList(PatientSearchFilter filter);

        IEnumerable<long> GetCustomerForTermByAbsence(int pageNumber, int pageSize, MemberTermByAbsenceFilter filter,
            out int totalRecords);
    }
}