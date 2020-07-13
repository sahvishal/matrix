using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class HealthAssessmentFactory : IHealthAssessmentFactory
    {
        public IEnumerable<HealthAssessmentQuestion> MapMultiple(IEnumerable<CustomerHealthQuestionsEntity> entities)
        {
            return entities.Select(Map).ToArray();
        }

        public HealthAssessmentQuestion Map(CustomerHealthQuestionsEntity entity)
        {
            var healthAssessmentQuestion = new HealthAssessmentQuestion
                                               {
                                                   ControlType = (DisplayControlType)entity.ControlType,
                                                   DisplaySequence = entity.DisplaySequence ?? 0,
                                                   ControlValues = !string.IsNullOrEmpty(entity.ControlValues) ? entity.ControlValues.Split(new[] { entity.ControlValueDelimiter }, StringSplitOptions.RemoveEmptyEntries) : null,
                                                   Id = entity.CustomerHealthQuestionId,
                                                   DefaultValue = entity.DefaultValue,
                                                   Label = entity.Label,
                                                   Question = entity.Question,
                                                   QuestionGroupId = entity.CustomerHealthQuestionGroupId,
                                                   ParentQuestionId = entity.ParentQuestionId,
                                                   IsForFemale = entity.IsForFemale,
                                                   IsActive = entity.IsActive
                                               };

            return healthAssessmentQuestion;
        }

        public IEnumerable<HealthAssessmentAnswer> MapMultiple(IEnumerable<CustomerHealthInfoEntity> entities)
        {
            return entities.Select(Map).ToArray();
        }

        public HealthAssessmentAnswer Map(CustomerHealthInfoEntity entity)
        {
            var healthAssessmentAnswer = new HealthAssessmentAnswer
                                             {
                                                 Answer = entity.HealthQuestionAnswer,
                                                 CustomerId = entity.CustomerId,
                                                 QuestionId = entity.CustomerHealthQuestionId,
                                                 DataRecorderMetaData = new DataRecorderMetaData(entity.CreatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.CreatedByOrgRoleUserId.Value) : null, entity.DateCreated ?? DateTime.Now, entity.DateModified),
                                                 EventCustomerId = entity.EventCustomerId
                                             };

            return healthAssessmentAnswer;
        }

        public IEnumerable<CustomerHealthInfoEntity> MapMultiple(IEnumerable<HealthAssessmentAnswer> healthAssessmentAnswers)
        {
            return healthAssessmentAnswers.Select(Map).ToArray();
        }

        public CustomerHealthInfoEntity Map(HealthAssessmentAnswer domain)
        {
            var entity = new CustomerHealthInfoEntity
            {
                HealthQuestionAnswer = domain.Answer,
                CustomerId = domain.CustomerId,
                CustomerHealthQuestionId = domain.QuestionId,
                DateCreated = domain.DataRecorderMetaData.DateCreated,
                EventCustomerId = domain.EventCustomerId,
                CreatedByOrgRoleUserId = domain.DataRecorderMetaData.DataRecorderCreator.Id > 0 ? domain.DataRecorderMetaData.DataRecorderCreator.Id : (long?)null
            };

            return entity;
        }

        public IEnumerable<HealthAssesmentArchiveAnswer> MapMultiple(IEnumerable<CustomerHealthInfoArchiveEntity> entities)
        {
            return entities.Select(Map).ToArray();
        }

        public HealthAssesmentArchiveAnswer Map(CustomerHealthInfoArchiveEntity entity)
        {
            var model = new HealthAssesmentArchiveAnswer();
            model.HealthAssessmentAnswer = new HealthAssessmentAnswer
                                               {
                                                   CustomerId = entity.CustomerId,
                                                   Answer = entity.HealthQuestionAnswer,
                                                   QuestionId = entity.CustomerHealthQuestionId,
                                                   EventCustomerId = entity.EventCustomerId,
                                                   DataRecorderMetaData = new DataRecorderMetaData(entity.CreatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.CreatedByOrgRoleUserId.Value) : null, entity.DateCreated, null),
                                               };
            model.ArchiveDate = entity.ArchiveDate.Value;
            model.Version = entity.Version;
            return model;
        }

        public IEnumerable<CustomerHealthInfoArchiveEntity> MapMultiple(long version, IEnumerable<HealthAssessmentAnswer> healthAssessmentAnswers)
        {
            return healthAssessmentAnswers.Select(a => Map(version, a)).ToArray();
        }

        public CustomerHealthInfoArchiveEntity Map(long version, HealthAssessmentAnswer healthAssessmentAnswer)
        {
            var entity = new CustomerHealthInfoArchiveEntity
            {
                Version = version,
                ArchiveDate = DateTime.Now,
                HealthQuestionAnswer = healthAssessmentAnswer.Answer,
                CustomerHealthQuestionId = healthAssessmentAnswer.QuestionId,
                CustomerId = healthAssessmentAnswer.CustomerId,
                EventCustomerId = healthAssessmentAnswer.EventCustomerId,
                CreatedByOrgRoleUserId =
                    healthAssessmentAnswer.DataRecorderMetaData != null && healthAssessmentAnswer.DataRecorderMetaData.DataRecorderCreator != null
                    && healthAssessmentAnswer.DataRecorderMetaData.DataRecorderCreator.Id > 0
                        ? healthAssessmentAnswer.DataRecorderMetaData.DataRecorderCreator.Id
                        : (long?)null,
                DateCreated = healthAssessmentAnswer.DataRecorderMetaData != null ? healthAssessmentAnswer.DataRecorderMetaData.DateCreated : DateTime.Now,
                IsNew = true
            };

            return entity;
        }

        public IEnumerable<HealthAssessmentQuestionGroup> MapMultiple(IEnumerable<CustomerHealthQuestionGroupEntity> entities)
        {
            return entities.Select(Map).ToArray();
        }

        public HealthAssessmentQuestionGroup Map(CustomerHealthQuestionGroupEntity entity)
        {
            var healthQuestionGroup = new HealthAssessmentQuestionGroup
                                          {
                                              Id = entity.CustomerHealthQuestionGroupId,
                                              Name = entity.Name,
                                              Description = entity.Description,
                                              IsClinicalQuestions = entity.IsClinicalQuestions,
                                              TestId = entity.TestId
                                          };
            if (entity.CustomerHealthQuestions != null && entity.CustomerHealthQuestions.Count > 0)
            {
                healthQuestionGroup.Questions = MapMultiple(entity.CustomerHealthQuestions);
            }
            return healthQuestionGroup;
        }

    }
}