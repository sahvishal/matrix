using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface ICustomerService
    {
        bool SaveCustomer(Customer customer, long updatedby, bool createHistory = true);
        List<CustomerTestimonialAggregate> GetCustomerTestimonials(bool? isAccepted, int pageNumber, int pageSize);
        List<CustomerTestimonialAggregate> GetAcceptedTestimonials(bool? isAccepted, string gender, int pageNumber, int pageSize);

        void MarkProspectCustomerConverted(long eventCustomerId);
        void UnMarkProspectCustomerConverted(long eventCustomerId, ProspectCustomerTag tag);
        Customer SaveCustomer(SchedulingCustomerEditModel model, bool isExistingCustomer);
        Customer SaveCustomer(HealthAssessmentHeaderEditModel headerModel, HealthAssessmentFooterEditModel footerModel, long orgRoleId);
        void UpdateCustomerShippingAddress(long customerId);
        MammoConsentEditModel GetClientNoticeEditModel(long customerId);
        void SavePrimaryCarePhysician(PrimaryCarePhysicianEditModel pcpEditModel, long customerId, long orgRoleUserId = 0);
        AbnConsentViewModel GetAbnModel(long eventCustomerId);
        string SetCustomerTag(Customer customer, long eventId, long orgRoleUserId, DateTime eventDate);
        AwvPcpConsentViewModel GetAwvPcpConsentViewModel(long customerId, long eventId);
        AwvPcpConsentViewModel GetAwvPcpConsentViewModel(Customer customer, Event eventData, PrimaryCarePhysician pcp, string signatureUrl, DateTime? signedDate = null);

        MammogramHistoryFormViewModel GetMammogramHistoryFormViewModel(long customerId);
        bool SaveCustomerOnly(Customer customer, long orgRoleId, bool createHistory = true);
        void UpdateIsLanguageBarrier(long customerId, bool isLanguageBarrier, long orgRoleId);
        bool UpdateIsIncorrectPhoneNumber(long customerId, bool isIncorrectPhoneNumber, long orgRoleId);
        bool UpdateDoNotCallStatus(long customerId, bool isRevertDoNotCall, long orgRoleId, long? sourceId = null);
        Customer UpdateDoNotCallStatus(Customer customer, bool isRevertDoNotCall, long? sourceId = null);
        Customer UpdateIsLanguageBarrier(Customer customer, bool isLanguageBarrier);
        Customer UpdateIsIncorrectPhoneNumber(Customer customer, bool isIncorrectPhoneNumber);

        Customer UpdateDoNotCallStatuswithReason(Customer customer, bool isRevertDoNotCall, ProspectCustomerTag prospectCustomerTag, long? sourceId = null);
    }
}