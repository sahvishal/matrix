using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ClinicalQuestionsHealthAssessmentHelper : IClinicalQuestionsHealthAssessmentHelper
    {
        private readonly IClinicalTestQualificationCriteriaRepository _clinicalTestQualificationCriteriaRepository;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly IHealthAssessmentTemplateRepository _healthAssessmentTemplateRepository;

        public ClinicalQuestionsHealthAssessmentHelper(IClinicalTestQualificationCriteriaRepository clinicalTestQualificationCriteriaRepository, IHealthAssessmentRepository healthAssessmentRepository, IHealthAssessmentTemplateRepository healthAssessmentTemplateRepository)
        {
            _clinicalTestQualificationCriteriaRepository = clinicalTestQualificationCriteriaRepository;
            _healthAssessmentRepository = healthAssessmentRepository;
            _healthAssessmentTemplateRepository = healthAssessmentTemplateRepository;
        }

        public void SetRecommendationLogic(long templateId, HealthAssessmentEditModel model)
        {
            var critarias = _clinicalTestQualificationCriteriaRepository.GetbyTemplateId(templateId);
            var critariasViewModels = Mapper.Map<IEnumerable<ClinicalTestQualificationCriteria>, IEnumerable<ClinicalTestQualificationCriteriaViewModel>>(critarias);
            var clinicalGroups = _healthAssessmentRepository.GetAllQuestionGroupWithQuestion(true);
            var template = _healthAssessmentTemplateRepository.GetById(templateId);

            CompleteClinicalQuestionCriteriaInfo(critariasViewModels, clinicalGroups, template.QuestionIds);

            if (!critariasViewModels.IsNullOrEmpty())
            {
                //Osteoporosis
                var recommendation = critariasViewModels.FirstOrDefault(x => TestGroup.OsteoTestIds.Contains(x.TestId));
                if (recommendation != null)
                {
                    model.BoneDensityRecommendationLogic = new QualificationRecommendationLogic
                    {
                        RecommendationLogic = recommendation.ToString(),
                        DisqualificationLogic = recommendation.DisqualificationLogic
                    };
                }

                //Peripheral Arterial Disease (PAD)/A/B Index
                recommendation = critariasViewModels.FirstOrDefault(x => TestGroup.PadTestIds.Contains(x.TestId));
                if (recommendation != null)
                {
                    model.ABIndexRecommendationLogic = new QualificationRecommendationLogic
                    {
                        RecommendationLogic = recommendation.ToString(),
                        DisqualificationLogic = recommendation.DisqualificationLogic
                    };
                }

                //AAA
                recommendation = critariasViewModels.FirstOrDefault(x => TestGroup.AaaTestIds.Contains(x.TestId));
                if (recommendation != null)
                {
                    model.AAARecommendationLogic = new QualificationRecommendationLogic
                    {
                        RecommendationLogic = recommendation.ToString(),
                        DisqualificationLogic = recommendation.DisqualificationLogic
                    };
                }

                //Stroke/Carotid Artery Ultrasound 
                recommendation = critariasViewModels.FirstOrDefault(x => TestGroup.StrokeTesIds.Contains(x.TestId));
                if (recommendation != null)
                {
                    model.CarotidRecommendationLogic = new QualificationRecommendationLogic
                    {
                        RecommendationLogic = recommendation.ToString(),
                        DisqualificationLogic = recommendation.DisqualificationLogic
                    };
                }

                //Echocardiogram
                recommendation = critariasViewModels.FirstOrDefault(x => TestGroup.EchoTestIds.Contains(x.TestId));
                if (recommendation != null)
                {
                    model.EchocardiogramRecommendationLogic = new QualificationRecommendationLogic
                    {
                        RecommendationLogic = recommendation.ToString(),
                        DisqualificationLogic = recommendation.DisqualificationLogic
                    };
                }

                recommendation = critariasViewModels.FirstOrDefault(x => TestGroup.SpiroTestIds.Contains(x.TestId));
                if (recommendation != null)
                {
                    model.SpirometryRecommendationLogic = new QualificationRecommendationLogic
                    {
                        RecommendationLogic = recommendation.ToString(),
                        DisqualificationLogic = recommendation.DisqualificationLogic
                    };
                }

                recommendation = critariasViewModels.FirstOrDefault(x => x.TestId == (long)TestType.IFOBT);
                if (recommendation != null)
                {
                    model.IFOBTRecommendationLogic = new QualificationRecommendationLogic
                    {
                        RecommendationLogic = recommendation.ToString(),
                        DisqualificationLogic = recommendation.DisqualificationLogic
                    };
                }

                recommendation = critariasViewModels.FirstOrDefault(x => x.TestId == (long)TestType.HcpCaDiabetesPanel);
                if (recommendation != null)
                {
                    model.DiabetesPanelRecommendationLogic = new QualificationRecommendationLogic
                    {
                        RecommendationLogic = recommendation.ToString(),
                        DisqualificationLogic = recommendation.DisqualificationLogic
                    };
                }

                recommendation = critariasViewModels.FirstOrDefault(x => x.TestId == (long)TestType.HcpCaBmp);
                if (recommendation != null)
                {
                    model.BmpRecommendationLogic = new QualificationRecommendationLogic
                    {
                        RecommendationLogic = recommendation.ToString(),
                        DisqualificationLogic = recommendation.DisqualificationLogic
                    };
                }

                recommendation = critariasViewModels.FirstOrDefault(x => x.TestId == (long)TestType.HcpCaLipidProfile);
                if (recommendation != null)
                {
                    model.LipidProfileRecommendationLogic = new QualificationRecommendationLogic
                    {
                        RecommendationLogic = recommendation.ToString(),
                        DisqualificationLogic = recommendation.DisqualificationLogic
                    };
                }

                recommendation = critariasViewModels.FirstOrDefault(x => x.TestId == (long)TestType.HcpCaMicroAlbuminCreatinine);
                if (recommendation != null)
                {
                    model.MicroAlbuminCreatinineRecommendationLogic = new QualificationRecommendationLogic
                    {
                        RecommendationLogic = recommendation.ToString(),
                        DisqualificationLogic = recommendation.DisqualificationLogic
                    };
                }

                recommendation = critariasViewModels.FirstOrDefault(x => x.TestId == (long)TestType.HcpCaHepatitisC);
                if (recommendation != null)
                {
                    model.HepatitisCRecommendationLogic = new QualificationRecommendationLogic
                    {
                        RecommendationLogic = recommendation.ToString(),
                        DisqualificationLogic = recommendation.DisqualificationLogic
                    };
                }
            }
        }

        public void CompleteClinicalQuestionCriteriaInfo(IEnumerable<ClinicalTestQualificationCriteriaViewModel> templateCriteria, IEnumerable<HealthAssessmentQuestionGroup> clinicalGroups, IEnumerable<long> selectedQuestionIds)
        {
            foreach (var criteriView in templateCriteria)
            {
                var clinicalTestGroup = clinicalGroups.First(x => x.TestId == criteriView.TestId);
                criteriView.GroupName = clinicalTestGroup.Name;
                var parentQuestions = clinicalTestGroup.Questions.Where(x => x.ParentQuestionId != null);
                var hasSectionsInQuestion = false;
                int count = 0;

                if (parentQuestions.IsNullOrEmpty())
                {
                    count = clinicalTestGroup.Questions.Count(x => x.Id != criteriView.MedicationQuestionId && selectedQuestionIds.Contains(x.Id));
                }
                else
                {
                    hasSectionsInQuestion = true;
                    var parentQuestionIds = parentQuestions.Select(x => x.ParentQuestionId).Distinct();

                    foreach (var questionId in parentQuestionIds)
                    {
                        var tempCount = clinicalTestGroup.Questions.Count(x => x.ParentQuestionId == questionId);
                        if (count > tempCount || count == 0)
                        {
                            count = tempCount;
                        }
                    }
                }
                criteriView.HasSectionsInQuestion = hasSectionsInQuestion;
                criteriView.TotalQuestionCount = count;
                if (criteriView.DisqualifierQuestionId <= 0) continue;

                var question = clinicalTestGroup.Questions.FirstOrDefault(x => x.Id == criteriView.DisqualifierQuestionId);
                if (question != null)
                {
                    criteriView.DisqualifierQuestionText = question.Question;
                }
            }
        }
    }
}