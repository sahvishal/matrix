using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface ICustomerClinicalQuestionAnswerRepository
    {
        IEnumerable<CustomerClinicalQuestionAnswer> GetCustomerClinicalQuestionAnswers(string guid, long customerId); 
        void SaveCustomerClinicalQuestionAnswers(IEnumerable<CustomerClinicalQuestionAnswer> answers);
        void DeleteCustomerClinicalQuestionAnswers(string guid, long customerId);
        IEnumerable<CustomerClinicalQuestionAnswer> GetByCustomerId(long customerId);
    }
}
