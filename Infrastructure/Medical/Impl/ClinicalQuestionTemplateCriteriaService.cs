using System.Collections.Generic;
using AutoMapper;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class ClinicalQuestionTemplateCriteriaService
    {
        private readonly IHealthAssessmentTemplateRepository _healthAssessmentTemplateRepository;
        private readonly IClinicalTestQualificationCriteriaRepository _clinicalTestQualificationCriteriaRepository;

        public ClinicalQuestionTemplateCriteriaService(IHealthAssessmentTemplateRepository healthAssessmentTemplateRepository,
            IClinicalTestQualificationCriteriaRepository clinicalTestQualificationCriteriaRepository)
        {
            _healthAssessmentTemplateRepository = healthAssessmentTemplateRepository;
            _clinicalTestQualificationCriteriaRepository = clinicalTestQualificationCriteriaRepository;
        }

        public IEnumerable<ClinicalTestQualificationCriteriaEditModel> Get(long templateId)
        {
            var template = _healthAssessmentTemplateRepository.GetById(templateId);
            var criterias = _clinicalTestQualificationCriteriaRepository.GetbyTemplateId(templateId);
            var criteriaEditModel = Mapper.Map<IEnumerable<ClinicalTestQualificationCriteria>, IEnumerable<ClinicalTestQualificationCriteriaEditModel>>(criterias);

            return criteriaEditModel;
        }

    }
}