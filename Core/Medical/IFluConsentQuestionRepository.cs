using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IFluConsentQuestionRepository
    {
        IEnumerable<FluConsentQuestion> GetAllQuestions();

        IEnumerable<long> GetQuestionIdsByTemplateId(long templateId);

        void SaveTemplateQuestions(IEnumerable<FluConsentTemplateQuestion> templateQuestions);

        void DeleteTemplateQuestions(long templateId);

    }
}
