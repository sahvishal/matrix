using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Sales.Domain;
using System;

namespace Falcon.App.Infrastructure.Sales.Impl
{
    [DefaultImplementation]
    public class CustomTagService : ICustomTagService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICorporateTagRepository _corporateTagRepository;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly ICustomTagFactory _customTagFactory;

        public CustomTagService(IOrganizationRepository organizationRepository, ICorporateTagRepository corporateTagRepository,
            ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository, ICustomTagFactory customTagFactory)
        {
            _organizationRepository = organizationRepository;
            _corporateTagRepository = corporateTagRepository;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _customTagFactory = customTagFactory;
        }

        public IEnumerable<CustomTagViewModel> GetCustomTagFilterList(CustomTagListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            var corporateTags = _corporateTagRepository.GetCorporateTagByFilter(filter, pageNumber, pageSize, out totalRecords);

            if (corporateTags == null || !corporateTags.Any())
                return null;

            long[] corporateIds = corporateTags.Select(m => m.CorporateId).ToArray();

            var organizations = _organizationRepository.GetOrganizations(corporateIds);

            var customerCountByTags = _corporateCustomerCustomTagRepository.GetCustomerCountByTag(corporateTags.Select(x => x.Tag).Distinct());

            var collection = _customTagFactory.Create(corporateTags, organizations, customerCountByTags);

            return collection;
        }

        public bool DeleteCorporateTag(long corporateTagId, long orgId)
        {
            var corporateTag = _corporateTagRepository.GetById(corporateTagId);

            return _corporateTagRepository.DeleteCustomTags(corporateTag.Tag, orgId, false);
        }

        public bool DisabledCorporateTag(long corporateTagId, bool disabled, long orgId)
        {
            return _corporateTagRepository.DisableCustomTag(corporateTagId, disabled, orgId);
        }

        public CustomTagEditViewModel GetCustomTag(long tagId)
        {
            var corporateTag= _corporateTagRepository.GetById(tagId);
            var customeTagViewModel = new CustomTagEditViewModel();
            if(corporateTag != null)
            {
                customeTagViewModel.CustomTag = corporateTag.Tag;
                customeTagViewModel.StartDate = corporateTag.StartDate;
                customeTagViewModel.EndDate = corporateTag.EndDate;
                customeTagViewModel.HealthPlanId = corporateTag.CorporateId;
                customeTagViewModel.TagId = corporateTag.Id;
            }
            return customeTagViewModel;
        }
        public void SaveCustomeTag(CustomTagEditViewModel model, long orgId)
        {
            _corporateTagRepository.Save(new CorporateTag
            {
                CorporateId = model.HealthPlanId,
                Tag = model.CustomTag.Trim(),
                DateCreated = DateTime.Now,
                StartDate =model.StartDate.Value,
                EndDate =model.EndDate.Value,
                CreatedBy = orgId,
                IsActive = true
            });
        }
        public void UpdateCustomeTag(CustomTagEditViewModel model)
        {
            _corporateTagRepository.Update(new CorporateTag
            {
                Id=model.TagId,
                StartDate = model.StartDate.Value,
                EndDate = model.EndDate.Value,
            });
        }
    }
}