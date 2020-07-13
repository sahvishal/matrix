using System;
using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IHealthAssessmentService
    {
        HealthAssessmentEditModel GetHealthAssessmentEditModel(long customerId, long eventId, int versionNumber = 0, bool showKynEditModel = false);
        void Save(HealthAssessmentEditModel model, long createdByOrgRoleUserId);
        HealthAssessmentFormEditModel GetModel(long eventId, long customerId, bool showKynEditModel = false, bool isBulkPrint = false);
        bool IsTestPurchasedWithHealthAssessment(long testId, List<Test> eventTests);
        IEnumerable<HealthAssessmentQuestion> GetQuestions(long eventId, long customerId);
        IEnumerable<OrderedPair<long, DateTime>> GetHealthAssesmentSavedDatePair(IEnumerable<long> eventCustomerIds);
        bool SaveClinicalQuestions(string guid,long eventId, long customerId, long organisationUserRoleId);
        bool UpdateClinicalQuestions(string guid, long eventId, long customerId, long organisationUserRoleId);
        StandingOrderFormHeaderEditModel GetStandingOrderFormHeaderEditModel(long customerId, long eventId);
    }
}