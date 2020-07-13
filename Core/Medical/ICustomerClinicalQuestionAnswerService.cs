using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface ICustomerClinicalQuestionAnswerService
    {
        CustomerClinicalQuestionEditModel Get(string guid, long customerId, long eventId, long clinicalQuestionTemplateId,long eventCustomerId=0);
        void Save(HealthAssessmentEditModel model, string guid, long clinicalQuestionTemplateId, long createdByOrgRoleUserId);
        IEnumerable<ClinicalTestQualificationViewModel> RecommendTestToCustomer(string guid, long customerId, long eventId);
    }
}
