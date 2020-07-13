using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IClinicalTestQualificationCriteriaRepository
    {
        IEnumerable<ClinicalTestQualificationCriteria> GetbyTemplateId(long templateId);
        void Save(IEnumerable<ClinicalTestQualificationCriteria> criterias);
        IEnumerable<ClinicalTestQualificationCriteria> GetbyTemplateIds(IEnumerable<long> templateIds);
        void DeleteTemplateCriteria(long temlateId);
    }
}