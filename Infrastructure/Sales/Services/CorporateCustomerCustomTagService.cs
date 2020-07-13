using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;

namespace Falcon.App.Infrastructure.Sales.Services
{
    [DefaultImplementation]
    public class CorporateCustomerCustomTagService : ICorporateCustomerCustomTagService
    {
        private readonly ICorporateCustomerCustomTagRepository _customerTagRepository;

        public CorporateCustomerCustomTagService(ICorporateCustomerCustomTagRepository customerTagRepository)
        {
            _customerTagRepository = customerTagRepository;
        }

        public CorporateCustomerCustomTag Save(CorporateCustomerCustomTag corporateTag)
        {
            var existingTag = _customerTagRepository.GetByCustomerAndTag(corporateTag.CustomerId, corporateTag.Tag);

            if (existingTag != null)
            {
                existingTag.IsActive = true;
                existingTag.DataRecorderMetaData.DateModified = DateTime.Now;
                existingTag.DataRecorderMetaData.DataRecorderModifier = corporateTag.DataRecorderMetaData.DataRecorderCreator;
                return _customerTagRepository.Save(existingTag);
            }

            return _customerTagRepository.Save(corporateTag);
        }
    }
}
