using System;
using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface ICustomerMedicareQuestionService
    {
        IEnumerable<MedicareQuestionGroupEditModel> GetEditModel(long eventCustomerId);
        IEnumerable<MedicareQuestionAnswer> GetAnswersByEventCustomerId(long eventCustomerId);
        void SaveCustomerMedicareAnswer(CustomerMedicareQuestionAnswerEditModel customerMedicareQuestionAnswer);
        IEnumerable<OrderedPair<long, DateTime>> GetEvenetCustomerMedicareSavedDatePair(long eventId);
        bool IsTestPurchased(long eventId, long customerId, long[] testId);
    }
}
