using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ClinicalTemplateService : IClinicalTemplateService
    {
        private readonly IHealthAssessmentTemplateRepository _healthAssessmentTemplateRepository;
        private readonly IClinicalTestQualificationCriteriaRepository _clinicalTestQualificationCriteriaRepository;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly IClinicalQuestionsHealthAssessmentHelper _clinicalQuestionsHealthAssessmentHelper;

        public ClinicalTemplateService(IHealthAssessmentTemplateRepository healthAssessmentTemplateRepository, IClinicalTestQualificationCriteriaRepository clinicalTestQualificationCriteriaRepository, IHealthAssessmentRepository healthAssessmentRepository, IClinicalQuestionsHealthAssessmentHelper clinicalQuestionsHealthAssessmentHelper)
        {
            _healthAssessmentTemplateRepository = healthAssessmentTemplateRepository;
            _clinicalTestQualificationCriteriaRepository = clinicalTestQualificationCriteriaRepository;
            _healthAssessmentRepository = healthAssessmentRepository;
            _clinicalQuestionsHealthAssessmentHelper = clinicalQuestionsHealthAssessmentHelper;
        }

        public HealthAssessmentTemplateListModel GetClinicalTemplate(HealthAssessmentTemplateListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            var templates = _healthAssessmentTemplateRepository.GetHealthAssessmentTemplate(filter, pageNumber, pageSize, out totalRecords);
            var templatesWithQuestion = _healthAssessmentTemplateRepository.GetByIds(templates.Select(x => x.Id));
            var templatesCriterias = _clinicalTestQualificationCriteriaRepository.GetbyTemplateIds(templates.Select(x => x.Id));
            var criteriaViewModels = Mapper.Map<IEnumerable<ClinicalTestQualificationCriteria>, IEnumerable<ClinicalTestQualificationCriteriaViewModel>>(templatesCriterias).ToList();
            var healthAssessmentTemplates = Mapper.Map<IEnumerable<HealthAssessmentTemplate>, IEnumerable<HealthAssessmentTemplateViewModel>>(templates);
            var clinicalGroups = _healthAssessmentRepository.GetAllQuestionGroupWithQuestion(true);

            foreach (var healthAssessmentTemplate in healthAssessmentTemplates)
            {
                List<ClinicalTestQualificationCriteriaViewModel> templateCriteria = null;
                if (!templatesCriterias.IsNullOrEmpty())
                {
                    templateCriteria = criteriaViewModels.Where(x => x.TemplateId == healthAssessmentTemplate.Id).ToList();
                }

                var selectedQuestionIds = templatesWithQuestion.First(x => x.Id == healthAssessmentTemplate.Id).QuestionIds;

                if (!templateCriteria.IsNullOrEmpty())
                {
                    _clinicalQuestionsHealthAssessmentHelper.CompleteClinicalQuestionCriteriaInfo(templateCriteria, clinicalGroups, selectedQuestionIds);
                }

                healthAssessmentTemplate.Criterias = templateCriteria;
            }

            var model = new HealthAssessmentTemplateListModel
            {
                HealthAssessmentTemplates = healthAssessmentTemplates,
                Filter = filter
            };

            return model;
        }



        public TemplateCriteriaEditModel GetTemplateCriteriaEditModel(long templateId)
        {
            var groups = _healthAssessmentRepository.GetQuestionWithGroupForTemplatId(templateId);
            var testids = groups.Where(x => x.TestId.HasValue).Select(x => x.TestId.Value).Distinct();

            var criteriaCollection = _clinicalTestQualificationCriteriaRepository.GetbyTemplateId(templateId);

            var criterias = new List<ClinicalTestQualificationCriteriaEditModel>();

            if (criteriaCollection != null && criteriaCollection.Any())
            {
                criterias = Mapper.Map<IEnumerable<ClinicalTestQualificationCriteria>, IEnumerable<ClinicalTestQualificationCriteriaEditModel>>(criteriaCollection).ToList();
            }

            var testIds = criterias.Select(x => x.TestId);
            testids = testids.Where(t => !testIds.Contains(t));

            criterias.AddRange(testids.Select(t => new ClinicalTestQualificationCriteriaEditModel
            {
                TestId = t,
                TemplateId = templateId
            }));

            return new TemplateCriteriaEditModel
            {
                Criteria = SetTotalNumberOfQuestionAndGroupName(criterias, templateId, groups),
                TemplateId = templateId
            };
        }

        private IEnumerable<ClinicalTestQualificationCriteriaEditModel> SetTotalNumberOfQuestionAndGroupName(IEnumerable<ClinicalTestQualificationCriteriaEditModel> criterias, long templateId, IEnumerable<HealthAssessmentQuestionGroup> groups)
        {
            var template = _healthAssessmentTemplateRepository.GetById(templateId);
            var selectedQuestionIds = template.QuestionIds;
            var finalCriteriaModel = new List<ClinicalTestQualificationCriteriaEditModel>();

            foreach (var healthAssessmentQuestionGroup in groups)
            {
                var parentQuestion = healthAssessmentQuestionGroup.Questions.Where(x => selectedQuestionIds.Contains(x.Id) && x.ParentQuestionId != null);
                int count = 0;
                if (parentQuestion.IsNullOrEmpty())
                {
                    count = healthAssessmentQuestionGroup.Questions.Count(x => selectedQuestionIds.Contains(x.Id));
                }
                else
                {
                    var parentQuestionIds = parentQuestion.Select(x => x.ParentQuestionId).Distinct();

                    foreach (var questionId in parentQuestionIds)
                    {
                        var tempCount = healthAssessmentQuestionGroup.Questions.Count(x => x.ParentQuestionId == questionId);
                        if (count > tempCount || count == 0)
                            count = tempCount;
                    }
                }

                var criteira = criterias.Single(x => x.TestId == healthAssessmentQuestionGroup.TestId);
                criteira.TotalQuestionCount = count;
                criteira.GroupName = healthAssessmentQuestionGroup.Name;
                finalCriteriaModel.Add(criteira);
            }

            return finalCriteriaModel;

        }

        public void SaveCriteria(TemplateCriteriaEditModel templateModel, long orgRoleUserId)
        {
            var validCriteriaConditions = templateModel.Criteria.Where(IsValidCriteria);
            var criteriaCollection = _clinicalTestQualificationCriteriaRepository.GetbyTemplateId(templateModel.TemplateId);
            var list = CreateClinicalTestQualificatonCriteriaDomain(validCriteriaConditions, criteriaCollection, orgRoleUserId, templateModel.TemplateId, templateModel.IsPublished);

            using (var scope = new TransactionScope())
            {
                _clinicalTestQualificationCriteriaRepository.DeleteTemplateCriteria(templateModel.TemplateId);

                if (!list.IsNullOrEmpty())
                    _clinicalTestQualificationCriteriaRepository.Save(list);

                if (templateModel.IsPublished)
                    _healthAssessmentTemplateRepository.PublishTemplate(templateModel.TemplateId);

                scope.Complete();
            }
        }

        private List<ClinicalTestQualificationCriteria> CreateClinicalTestQualificatonCriteriaDomain(IEnumerable<ClinicalTestQualificationCriteriaEditModel> validCriteriaConditions,
            IEnumerable<ClinicalTestQualificationCriteria> criteriaCollection, long orgRoleUserId, long templateId, bool isPublish)
        {
            var list = new List<ClinicalTestQualificationCriteria>();
            if (!validCriteriaConditions.IsNullOrEmpty())
            {
                var domainList = Mapper.Map<IEnumerable<ClinicalTestQualificationCriteriaEditModel>, IEnumerable<ClinicalTestQualificationCriteria>>(validCriteriaConditions);

                if (criteriaCollection != null && criteriaCollection.Any())
                {
                    list.AddRange(from inpersistence in criteriaCollection
                                  let domain = domainList.SingleOrDefault(x => x.TestId == inpersistence.TestId)
                                  where domain != null
                                  select CreateDomain(inpersistence, domain, isPublish, orgRoleUserId));
                }

                var testIds = list.Select(x => x.TestId);

                domainList = domainList.Where(x => !testIds.Contains(x.TestId));

                if (!domainList.IsNullOrEmpty())
                {
                    foreach (var criteria in domainList)
                    {
                        criteria.DataRecorderMetaData = new DataRecorderMetaData(new OrganizationRoleUser(orgRoleUserId),
                            DateTime.Now, null);
                        criteria.TemplateId = templateId;
                        criteria.IsPublished = isPublish;
                        list.Add(criteria);
                    }
                }
            }

            return list;
        }

        public bool IsValidForPublish(IEnumerable<ClinicalTestQualificationCriteriaEditModel> criterias)
        {
            return criterias.All(IsValidCriteria);
        }

        private bool IsValidCriteria(ClinicalTestQualificationCriteriaEditModel model)
        {
            if (model.AgeCriteriaSelected && model.AgeCondition > 0 && IsValidAgeCondition(model))
                return true;
            if (model.GenderCriteriaSelected && (model.Gender == Gender.Male || model.Gender == Gender.Female))
                return true;
            if (model.OnMedication && model.MedicationQuestionId > 0)
                return true;
            if (model.NumberOfQuestionCriteriaSelected && model.NumberOfQuestion > 0 && !string.IsNullOrEmpty(model.Answer))
                return true;
            if (model.DisqualifierQuestionSelected && model.DisqualifierQuestionId > 0 && !string.IsNullOrEmpty(model.DisqualifierQuestionAnswer))
                return true;

            return false;
        }

        public bool IsValidAgeCondition(ClinicalTestQualificationCriteriaEditModel model)
        {
            if (model.AgeCondition <= 0) return false;

            switch ((ComparisonOperators)model.AgeCondition)
            {
                case ComparisonOperators.LessThan:
                case ComparisonOperators.LessThanEqualTo:
                    return model.AgeMax.HasValue;
                case ComparisonOperators.GreaterThan:
                case ComparisonOperators.GreaterThanEqualTo:
                    return model.AgeMin.HasValue;
                case ComparisonOperators.Between:
                    return model.AgeMin.HasValue && model.AgeMax.HasValue;
                default:
                    return false;

            }

        }

        private ClinicalTestQualificationCriteria CreateDomain(ClinicalTestQualificationCriteria inpersistence, ClinicalTestQualificationCriteria domain, bool isPublised, long orgRoleUserId)
        {
            domain.DataRecorderMetaData = inpersistence.DataRecorderMetaData;
            domain.IsPublished = isPublised;
            domain.DataRecorderMetaData.DateModified = DateTime.Now;
            domain.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(orgRoleUserId);

            return domain;
        }
    }
}