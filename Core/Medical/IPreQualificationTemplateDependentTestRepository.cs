using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IPreQualificationTemplateDependentTestRepository
    {
        IEnumerable<PreQualificationTemplateDependentTest> GetByTemplateId(long templateId);

        void SaveCollection(IEnumerable<PreQualificationTemplateDependentTest> dependentTests);

        void DeactivateByTemplateId(long templateId);

        IEnumerable<PreQualificationTemplateDependentTest> GetByTemplateIds(long[] templateIds);
    }
}
