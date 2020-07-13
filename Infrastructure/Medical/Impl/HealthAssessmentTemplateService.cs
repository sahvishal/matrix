using System;
using System.Transactions;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class HealthAssessmentTemplateService : IHealthAssessmentTemplateService
    {
        private readonly IHealthAssessmentTemplateRepository _healthAssessmentTemplateRepository;

        public HealthAssessmentTemplateService(IHealthAssessmentTemplateRepository healthAssessmentTemplateRepository)
        {
            _healthAssessmentTemplateRepository = healthAssessmentTemplateRepository;
        }

        public HealthAssessmentTemplateEditModel SaveTemplate(HealthAssessmentTemplateEditModel model, long organizationRoleUserId)
        {
            HealthAssessmentTemplate templateinDb = null;

            var template = Mapper.Map<HealthAssessmentTemplateEditModel, HealthAssessmentTemplate>(model);

            if (template.Id > 0)
            {
                templateinDb = _healthAssessmentTemplateRepository.GetById(template.Id);
                template.DataRecorderMetaData = templateinDb.DataRecorderMetaData;
                template.DataRecorderMetaData.DateModified = DateTime.Now;
                template.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(organizationRoleUserId);
                if (!templateinDb.IsPublished && template.IsPublished)
                    template.PublicationDate = DateTime.Now;
            }
            else
            {
                template.DataRecorderMetaData = new DataRecorderMetaData(organizationRoleUserId, DateTime.Now, null);
                if (template.IsPublished)
                    template.PublicationDate = DateTime.Now;
            }

            using (var scope = new TransactionScope())
            {
                template = _healthAssessmentTemplateRepository.Save(template);
                scope.Complete();
            }

            model.Id = template.Id;

            return model;
        }

        public HealthAssessmentTemplateEditModel GetHealthAssessmentTemplate(long templateId, long category)
        {
            HealthAssessmentTemplateEditModel model = null;
            if (templateId > 0)
            {
                var template = _healthAssessmentTemplateRepository.GetById(templateId);
                model = Mapper.Map<HealthAssessmentTemplate, HealthAssessmentTemplateEditModel>(template);
                model.IsDefault = false;
                model.IsPublished = false;
                model.IsNewTemplate = false;
                model.Id = 0;
            }
            else
            {
                model = new HealthAssessmentTemplateEditModel
                {
                    IsActive = true,
                    IsNewTemplate = true,
                    Category = category
                };
            }

            return model;
        }

       
    }
}
