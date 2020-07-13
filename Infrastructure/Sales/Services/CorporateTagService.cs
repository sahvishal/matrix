using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Sales.Services
{
    [DefaultImplementation]
    public class CorporateTagService : ICorporateTagService
    {
        private readonly ICorporateTagRepository _corporateTagRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;

        public CorporateTagService(ICorporateTagRepository corporateTagRepository, ICorporateAccountRepository corporateAccountRepository)
        {
            _corporateTagRepository = corporateTagRepository;
            _corporateAccountRepository = corporateAccountRepository;
        }

        public CorporateTag Save(CorporateTag corporateTag)
        {
            return _corporateTagRepository.Save(corporateTag);
        }

        private IEnumerable<CorporateTag> GetByCorporateId(long id)
        {
            return _corporateTagRepository.GetByCorporateId(id, false);
        }

        public CorporateTagViewModel GetTagViewModel(long accountId)
        {
            var account = (((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(accountId));
            var tags = GetByCorporateId(accountId);

            return new CorporateTagViewModel
            {
                AccountId = account.Id,
                Tag = account.Tag,
                CustomTags = tags == null ? null : tags.Select(x => x.Tag).ToArray()
            };
        }

        public void Save(List<string> tags, long corporateId, long orgId)
        {
            var list = GetByCorporateId(corporateId);
            var tagsAlreadySaved = new List<string>();

            if (!list.IsNullOrEmpty())
            {
                tagsAlreadySaved = list.Select(x => x.Tag).ToList();
            }

            SaveTags(tags.Where(t => !tagsAlreadySaved.Contains(t)).ToList(), corporateId, orgId);
        }

        private void SaveTags(IEnumerable<string> tags, long corporateId, long orgId)
        {
            foreach (var tag in tags)
            {
                _corporateTagRepository.Save(new CorporateTag
                {
                    CorporateId = corporateId,
                    Tag = tag,
                    DateCreated = DateTime.Now,
                    CreatedBy = orgId,
                    IsActive = true
                });
            }
        }

        public IEnumerable<string> DisabledTagsInUsed(IEnumerable<string> tags, long corporateId)
        {
            if (tags == null || !tags.Any()) return null;
            
            var corporateTags = _corporateTagRepository.GetByCorporateId(corporateId);

            return corporateTags.Where(x => x.IsDisabled && tags.Contains(x.Tag)).Select(x => x.Tag).ToArray();
        }
    }
}
