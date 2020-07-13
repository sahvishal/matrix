using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class PackageMapper : DomainEntityMapper<Package, PackageEntity>
    {
        private readonly IMapper<Test, TestEntity> _testMapper;

        public PackageMapper(IMapper<Test, TestEntity> testMapper)
        {
            _testMapper = testMapper;
        }

        protected override void MapDomainFields(PackageEntity entity, Package domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.PackageId;
            domainObjectToMapTo.Price = entity.Price;
            domainObjectToMapTo.Name = entity.PackageName;
            domainObjectToMapTo.Description = entity.Description;
            domainObjectToMapTo.ShowInPublicWebsite = entity.DescriptiononPublicWebsite;
            domainObjectToMapTo.IsSelectedByDefaultforEvent = entity.IsSelectedByDefaultForEvent;
            domainObjectToMapTo.PackageTypeId = entity.PackageTypeId;
            domainObjectToMapTo.DescriptiononUpsellSection = entity.DescriptiononUpsellSection;
            domainObjectToMapTo.DataRecorderMetaData = new DataRecorderMetaData(entity.CreatedByOrgRoleUserId, entity.DateCreated, entity.DateModified)
                                                           {
                                                                DataRecorderModifier = entity.UpdatedByOrgRoleUserId.HasValue ? new OrganizationRoleUser(entity.UpdatedByOrgRoleUserId.Value) : null
                                                           };

            domainObjectToMapTo.RelativeOrder = entity.RelativeOrder;
            domainObjectToMapTo.IsActive = entity.IsActive;
            
            domainObjectToMapTo.Tests = new List<Test>();
            if (entity.TestCollectionViaPackageTest != null)
            {
                foreach (var testEntity in entity.TestCollectionViaPackageTest)
                {
                    if (testEntity != null)
                    {
                        domainObjectToMapTo.Tests.Add(_testMapper.Map(testEntity));
                    }
                }
            }
            domainObjectToMapTo.ForOrderDisplayFileId = entity.ForOrderDisplayFileId;
            domainObjectToMapTo.PackageInfoUrl = entity.PackageInfoUrl;
            domainObjectToMapTo.ScreeningTime = entity.ScreeningTime ?? 0;
            domainObjectToMapTo.HealthAssessmentTemplateId = entity.HafTemplateId;
            domainObjectToMapTo.Gender = entity.Gender;

        }

        protected override void MapEntityFields(Package domainObject, PackageEntity entityToMapTo)
        {
            entityToMapTo.PackageId = domainObject.Id;
            entityToMapTo.Price = domainObject.Price;
            entityToMapTo.PackageName = domainObject.Name;
            entityToMapTo.Description = domainObject.Description;
            entityToMapTo.DescriptiononPublicWebsite = domainObject.ShowInPublicWebsite;
            entityToMapTo.PackageTypeId = domainObject.PackageTypeId;
            entityToMapTo.RelativeOrder = domainObject.RelativeOrder;
            entityToMapTo.DescriptiononUpsellSection = domainObject.DescriptiononUpsellSection;
            
            entityToMapTo.ScreeningTime = domainObject.ScreeningTime > 0 ? (int?)domainObject.ScreeningTime : null;
            entityToMapTo.Fields["ScreeningTime"].IsChanged = true;

            if (domainObject.DataRecorderMetaData != null)
            {
                entityToMapTo.CreatedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
                entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
                entityToMapTo.DateModified = domainObject.DataRecorderMetaData.DateModified;

                if (domainObject.DataRecorderMetaData.DataRecorderModifier != null)
                    entityToMapTo.UpdatedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderModifier.Id;
            }

            entityToMapTo.IsSelectedByDefaultForEvent = domainObject.IsSelectedByDefaultforEvent;

            entityToMapTo.ForOrderDisplayFileId = domainObject.ForOrderDisplayFileId;
            entityToMapTo.Fields["ForOrderDisplayFileId"].IsChanged = true;

            entityToMapTo.PackageInfoUrl = domainObject.PackageInfoUrl;
            entityToMapTo.Fields["PackageInfoUrl"].IsChanged = true;

            entityToMapTo.HafTemplateId = domainObject.HealthAssessmentTemplateId.HasValue && domainObject.HealthAssessmentTemplateId.Value > 0
                                              ? domainObject.HealthAssessmentTemplateId
                                              : null;
            entityToMapTo.Fields["HafTemplateId"].IsChanged = true;

            entityToMapTo.IsActive = true;

            entityToMapTo.Gender = domainObject.Gender;
            entityToMapTo.Fields["Gender"].IsChanged = true;
        }
    }
}