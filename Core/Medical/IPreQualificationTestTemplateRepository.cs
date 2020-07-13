using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IPreQualificationTestTemplateRepository
    {
        IEnumerable<PreQualificationTestTemplate> GetByTestId(long testId);
        PreQualificationTestTemplate GetById(long id);
        PreQualificationTestTemplate Save(PreQualificationTestTemplate domainObject, IEnumerable<PreQualifiedQuestionEditModel> questions);
        IEnumerable<long> GetQuestionIdsByTemplateId(long id);
        IEnumerable<PreQualificationTestTemplate> GetByFilters(PreQualifiedQuestionTemplateModelFilter filter, int pageNumber, int pageSize, out int totalRecords);
        PreQualificationTestTemplate GetByName(string templateName);
        IEnumerable<OrderedPair<long, long>> GetTemplateIdQuestionIdPairByTemplateIds(long[] ids);
        IEnumerable<PreQualificationTestTemplate> GetByIds(long[] ids);
        IEnumerable<PreQualificationTestTemplate> GetByTemplateIds(IEnumerable<long> ids);
    }
}
