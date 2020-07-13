using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Medical.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<ClinicalTestQualificationCriteria, ClinicalTestQualificationCriteriaEntity>))]
    public class ClinicalTestQualificationCriteriaMapper : DomainEntityMapper<ClinicalTestQualificationCriteria, ClinicalTestQualificationCriteriaEntity>
    {

        protected override void MapDomainFields(ClinicalTestQualificationCriteriaEntity entity, ClinicalTestQualificationCriteria domainObjectToMapTo)
        {
            domainObjectToMapTo.Gender = (Gender)entity.Gender;
            domainObjectToMapTo.NumberOfQuestion = entity.NumberOfQuestion;
            domainObjectToMapTo.Answer = entity.Answer;
            domainObjectToMapTo.OnMedication = entity.OnMedication;
            domainObjectToMapTo.AgeMin = entity.AgeMin;
            domainObjectToMapTo.AgeMax = entity.AgeMax;
            domainObjectToMapTo.AgeCondition = entity.AgeCondition;
            domainObjectToMapTo.MedicationQuestionId = entity.MedicationQuestionId;
            domainObjectToMapTo.TemplateId = entity.TemplateId;
            domainObjectToMapTo.TestId = entity.TestId;
            domainObjectToMapTo.IsPublished = entity.IsPublished;
            domainObjectToMapTo.DisqualifierQuestionId = entity.DisqualifierQuestionId;
            domainObjectToMapTo.DisqualifierQuestionAnswer = entity.DisqualifierQuestionAnswer;
            domainObjectToMapTo.DataRecorderMetaData = new DataRecorderMetaData(entity.CreatedBy, entity.CreatedOn, entity.ModifiedOn.HasValue ? entity.ModifiedOn : null)
                                                        {
                                                            DataRecorderModifier =
                                                                entity.ModifiedBy.HasValue ? new OrganizationRoleUser(entity.ModifiedBy.Value) : null
                                                        };

        }

        protected override void MapEntityFields(ClinicalTestQualificationCriteria domainObject, ClinicalTestQualificationCriteriaEntity entityToMapTo)
        {
            entityToMapTo.Gender = (long)domainObject.Gender;
            entityToMapTo.NumberOfQuestion = domainObject.NumberOfQuestion;
            entityToMapTo.Fields["NumberOfQuestion"].IsChanged = true;

            entityToMapTo.Answer = domainObject.Answer;
            entityToMapTo.Fields["Answer"].IsChanged = true;

            entityToMapTo.OnMedication = domainObject.OnMedication;
            entityToMapTo.Fields["OnMedication"].IsChanged = true;

            entityToMapTo.AgeMin = domainObject.AgeMin;
            entityToMapTo.Fields["AgeMin"].IsChanged = true;

            entityToMapTo.AgeMax = domainObject.AgeMax;
            entityToMapTo.Fields["AgeMax"].IsChanged = true;

            entityToMapTo.AgeCondition = domainObject.AgeCondition;
            entityToMapTo.Fields["AgeCondition"].IsChanged = true;

            entityToMapTo.MedicationQuestionId = domainObject.MedicationQuestionId;
            entityToMapTo.Fields["MedicationQuestionId"].IsChanged = true;

            entityToMapTo.DisqualifierQuestionAnswer = domainObject.DisqualifierQuestionAnswer;
            entityToMapTo.Fields["DisqualifierQuestionAnswer"].IsChanged = true;

            entityToMapTo.DisqualifierQuestionId = domainObject.DisqualifierQuestionId;
            entityToMapTo.Fields["DisqualifierQuestionId"].IsChanged = true;
            
            entityToMapTo.TemplateId = domainObject.TemplateId;
            entityToMapTo.TestId = domainObject.TestId;
            entityToMapTo.IsPublished = domainObject.IsPublished;
            entityToMapTo.CreatedBy = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
            entityToMapTo.CreatedOn = domainObject.DataRecorderMetaData.DateCreated;
            entityToMapTo.ModifiedBy = domainObject.DataRecorderMetaData.DataRecorderModifier.Id;
            entityToMapTo.ModifiedOn = domainObject.DataRecorderMetaData.DateModified;

        }
    }
}
