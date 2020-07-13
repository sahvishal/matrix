using Falcon.App.Core.Medical.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class TestMapper : DomainEntityMapper<Test, TestEntity>
    {
        protected override void MapDomainFields(TestEntity entity, Test domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.TestId;
            domainObjectToMapTo.Name = entity.Name;
            domainObjectToMapTo.Alias = entity.Alias;
            domainObjectToMapTo.Price = entity.Price;
            domainObjectToMapTo.PackagePrice = entity.DefaultPackagePrice;
            domainObjectToMapTo.RefundPrice = entity.RefundPrice;
            domainObjectToMapTo.PackageRefundPrice = entity.DefaultPackageRefundPrice;
            domainObjectToMapTo.Description = entity.Description;
            domainObjectToMapTo.RelativeOrder = entity.RelativeOrder;
            domainObjectToMapTo.CPTCode = string.IsNullOrWhiteSpace(entity.Cptcode) ? string.Empty : entity.Cptcode;
            domainObjectToMapTo.IsRecordable = entity.IsRecordable;
            domainObjectToMapTo.IsReviewable = entity.IsTestReviewableByPhysician;
            domainObjectToMapTo.ShowinCustomerPdf = entity.ShowInCustomerPdf;
            domainObjectToMapTo.MinAge = entity.MinAge;
            domainObjectToMapTo.MaxAge = entity.MaxAge;
            domainObjectToMapTo.IsActive = entity.IsActive;
            domainObjectToMapTo.DiagnosisCode = entity.DiagnosisCode;
            domainObjectToMapTo.ShowInAlaCarte = entity.ShowInAlaCarte;
            domainObjectToMapTo.ScreeningTime = entity.ScreeningTime ?? -1;
            domainObjectToMapTo.HealthAssessmentTemplateId = entity.HafTemplateId;
            domainObjectToMapTo.IsSelectedByDefaultforEvent = entity.IsSelectedByDefaultForEvent;
            domainObjectToMapTo.Gender = entity.Gender;
            domainObjectToMapTo.GroupId = entity.GroupId;
            domainObjectToMapTo.ReimbursementRate = entity.ReimbursementRate;
            domainObjectToMapTo.WithPackagePrice = entity.WithPackagePrice;
            domainObjectToMapTo.IsDefaultSelectionForPackage = entity.IsDefaultSelectionForPackage;
            domainObjectToMapTo.IsDefaultSelectionForOrder = entity.IsDefaultSelectionForOrder;
            domainObjectToMapTo.MediaUrl = entity.MediaUrl;
            domainObjectToMapTo.IsBillableToHealthPlan = entity.IsBillableToHealthPlan;

            domainObjectToMapTo.DateCreated = entity.DateCreated;
            domainObjectToMapTo.DateModified = entity.DateModified;
            domainObjectToMapTo.PreQualificationQuestionTemplateId = entity.PreQualificationQuestionTemplateId;

            domainObjectToMapTo.ResultEntryTypeId = entity.ResultEntryTypeId;
            domainObjectToMapTo.ChatStartDate = entity.ChatStartDate;
        }

        protected override void MapEntityFields(Test domainObject, TestEntity entityToMapTo)
        {
            entityToMapTo.TestId = domainObject.Id;
            entityToMapTo.Name = domainObject.Name;
            entityToMapTo.Alias = domainObject.Alias;
            entityToMapTo.Price = domainObject.Price;
            entityToMapTo.DefaultPackagePrice = domainObject.PackagePrice;
            entityToMapTo.RefundPrice = domainObject.RefundPrice;
            entityToMapTo.DefaultPackageRefundPrice = domainObject.PackageRefundPrice;
            entityToMapTo.Description = domainObject.Description;
            entityToMapTo.RelativeOrder = domainObject.RelativeOrder;

            entityToMapTo.Cptcode = domainObject.CPTCode;
            entityToMapTo.Fields["Cptcode"].IsChanged = true;

            entityToMapTo.IsRecordable = domainObject.IsRecordable;
            entityToMapTo.IsTestReviewableByPhysician = domainObject.IsReviewable;
            entityToMapTo.ShowInCustomerPdf = domainObject.ShowinCustomerPdf;

            entityToMapTo.MinAge = domainObject.MinAge;
            entityToMapTo.Fields["MinAge"].IsChanged = true;

            entityToMapTo.MaxAge = domainObject.MaxAge;
            entityToMapTo.Fields["MaxAge"].IsChanged = true;

            entityToMapTo.IsActive = domainObject.IsActive;

            entityToMapTo.DiagnosisCode = domainObject.DiagnosisCode;
            entityToMapTo.Fields["DiagnosisCode"].IsChanged = true;
            entityToMapTo.ShowInAlaCarte = domainObject.ShowInAlaCarte;

            entityToMapTo.ScreeningTime = domainObject.ScreeningTime >= 0 ? (int?)domainObject.ScreeningTime : null;
            entityToMapTo.Fields["ScreeningTime"].IsChanged = true;

            entityToMapTo.HafTemplateId = domainObject.HealthAssessmentTemplateId.HasValue && domainObject.HealthAssessmentTemplateId.Value > 0
                                              ? domainObject.HealthAssessmentTemplateId
                                              : null;
            entityToMapTo.Fields["HafTemplateId"].IsChanged = true;
            entityToMapTo.IsSelectedByDefaultForEvent = domainObject.IsSelectedByDefaultforEvent;
            entityToMapTo.Gender = domainObject.Gender;
            entityToMapTo.GroupId = domainObject.GroupId;
            entityToMapTo.ReimbursementRate = domainObject.ReimbursementRate;
            entityToMapTo.WithPackagePrice = domainObject.WithPackagePrice;
            entityToMapTo.IsDefaultSelectionForPackage = domainObject.IsDefaultSelectionForPackage;
            entityToMapTo.IsDefaultSelectionForOrder = domainObject.IsDefaultSelectionForOrder;
            entityToMapTo.MediaUrl = domainObject.MediaUrl;
            entityToMapTo.Fields["MediaUrl"].IsChanged = true;
            entityToMapTo.IsBillableToHealthPlan = domainObject.IsBillableToHealthPlan;

            entityToMapTo.DateModified = domainObject.DateModified;
            entityToMapTo.PreQualificationQuestionTemplateId = domainObject.PreQualificationQuestionTemplateId;
            entityToMapTo.Fields["PreQualificationQuestionTemplateId"].IsChanged = true;

            entityToMapTo.ResultEntryTypeId = domainObject.IsRecordable && domainObject.ResultEntryTypeId.HasValue && domainObject.ResultEntryTypeId.Value > 0
                                              ? domainObject.ResultEntryTypeId : null;
            entityToMapTo.Fields["ResultEntryTypeId"].IsChanged = true;

            entityToMapTo.ChatStartDate = domainObject.ChatStartDate;
            entityToMapTo.Fields["ChatStartDate"].IsChanged = true;
        }
    }
}