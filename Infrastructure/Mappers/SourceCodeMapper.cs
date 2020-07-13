using System;
using System.Linq;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Infrastructure.Mappers
{
    public class SourceCodeMapper : DomainEntityMapper<SourceCode, CouponsEntity>
    {
        protected override void MapDomainFields(CouponsEntity entity, SourceCode domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.CouponId;
            domainObjectToMapTo.CouponCode = entity.CouponCode;
            domainObjectToMapTo.CouponDescription = entity.CouponDescription;
            domainObjectToMapTo.DiscountType = (DiscountType)entity.CouponTypeId ;
            domainObjectToMapTo.DiscountValueType = (entity.IsPercentage ? DiscountValueType.Percent : DiscountValueType.Money);
            domainObjectToMapTo.ValidityStartDate = entity.ValidityStartDate;
            domainObjectToMapTo.ValidityEndDate = entity.ValidityEndDate;
            domainObjectToMapTo.CouponValue = entity.CouponValue;
            domainObjectToMapTo.CustomerType = entity.CustomerRange.HasValue ? (CustomerType)entity.CustomerRange.Value : (CustomerType)(- 1);
            domainObjectToMapTo.MaximumNumberTimesUsed = entity.MaximumNumberTimesUsed;
            domainObjectToMapTo.MinimumPurchaseAmount = entity.MinimumPurchaseAmount;
            domainObjectToMapTo.IsActive = entity.IsActive;

            domainObjectToMapTo.DataRecorderMetaData=new DataRecorderMetaData
                                                         {
                                                             DataRecorderCreator = new OrganizationRoleUser(entity.CreatedByOrgRoleUserId),
                                                             DateCreated = entity.DateCreated,
                                                             DateModified = entity.DateModified
                                                         };

            if (entity.ModifiedByOrgRoleUserId.HasValue)
                domainObjectToMapTo.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(entity.ModifiedByOrgRoleUserId.Value);

            if(entity.CouponSignUpMode != null && entity.CouponSignUpMode.Count > 0)
            {
                domainObjectToMapTo.SelectedSignUpModes = entity.CouponSignUpMode.Where(sm => sm.SignUpMode > 0).Select(sm => (SignUpMode)sm.SignUpMode).ToArray();
            }

            if(entity.PackageSourceCodeDiscount != null && entity.PackageSourceCodeDiscount.Count > 0)
            {
                domainObjectToMapTo.PackageDiscounts = entity.PackageSourceCodeDiscount
                    .Select(scd => new SourceCodeItemWiseDiscount { Id = scd.PackageId, DiscountAmount = scd.Discount, DiscountValueType = (scd.IsPercentage ? DiscountValueType.Percent : DiscountValueType.Money) }).ToArray();
            }

            if(entity.TestSourceCodeDiscount!=null && entity.TestSourceCodeDiscount.Count>0)
            {
                domainObjectToMapTo.TestDiscounts =
                    entity.TestSourceCodeDiscount.Select(scd =>
                        new SourceCodeItemWiseDiscount
                            {
                                Id = scd.TestId,
                                DiscountAmount = scd.Discount,
                                DiscountValueType = (scd.IsPercentage ? DiscountValueType.Percent : DiscountValueType.Money)
                            }).ToArray();
            }

            if (entity.ProductSourceCodeDiscount != null && entity.ProductSourceCodeDiscount.Count > 0)
            {
                domainObjectToMapTo.ProductDiscounts = entity.ProductSourceCodeDiscount
                    .Select(scd => new SourceCodeItemWiseDiscount { Id = scd.ProductId, DiscountAmount = scd.Discount, DiscountValueType = (scd.IsPercentage ? DiscountValueType.Percent : DiscountValueType.Money) }).ToArray();
            }

            if (entity.ShippingOptionSourceCodeDiscount != null && entity.ShippingOptionSourceCodeDiscount.Count > 0)
            {
                domainObjectToMapTo.ShippingDiscounts = entity.ShippingOptionSourceCodeDiscount
                    .Select(scd => new SourceCodeItemWiseDiscount { Id = scd.ShippingOptionId, DiscountAmount = scd.Discount, DiscountValueType = (scd.IsPercentage ? DiscountValueType.Percent : DiscountValueType.Money) }).ToArray();
            }

            if(entity.EventCoupons!=null && entity.EventCoupons.Count>0)
            {
                domainObjectToMapTo.EventIds = entity.EventCoupons.Select(ec => ec.EventId).ToArray();
            }
            
        }

        protected override void MapEntityFields(SourceCode domainObject, CouponsEntity entityToMapTo)
        {
            entityToMapTo.CouponId = domainObject.Id;
            entityToMapTo.CouponCode = domainObject.CouponCode;
            entityToMapTo.CouponDescription = domainObject.CouponDescription;
            entityToMapTo.Fields["CouponDescription"].IsChanged = true;

            entityToMapTo.CouponTypeId = (int)domainObject.DiscountType;
            entityToMapTo.IsPercentage = (domainObject.DiscountValueType == DiscountValueType.Percent);
            entityToMapTo.ValidityStartDate = domainObject.ValidityStartDate;
            entityToMapTo.ValidityEndDate = domainObject.ValidityEndDate;
            entityToMapTo.Fields["ValidityEndDate"].IsChanged = true;

            entityToMapTo.CouponValue = domainObject.CouponValue;
            entityToMapTo.CustomerRange = (byte) domainObject.CustomerType;
            entityToMapTo.MaximumNumberTimesUsed = domainObject.MaximumNumberTimesUsed;
            entityToMapTo.MinimumPurchaseAmount = domainObject.MinimumPurchaseAmount;
            entityToMapTo.IsActive = true;
            entityToMapTo.CreatedByOrgRoleUserId = (domainObject.DataRecorderMetaData != null && domainObject.DataRecorderMetaData.DataRecorderCreator != null) ? domainObject.DataRecorderMetaData.DataRecorderCreator.Id :0;
            entityToMapTo.ModifiedByOrgRoleUserId = (domainObject.DataRecorderMetaData != null && domainObject.DataRecorderMetaData.DataRecorderModifier != null) ? domainObject.DataRecorderMetaData.DataRecorderModifier.Id :(long?)null;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData != null ? domainObject.DataRecorderMetaData.DateCreated : DateTime.Now;
            entityToMapTo.DateModified = domainObject.DataRecorderMetaData != null && domainObject.DataRecorderMetaData.DateModified.HasValue ? domainObject.DataRecorderMetaData.DateModified.Value : (DateTime?)null;
            entityToMapTo.IsNew = domainObject.Id <= 0;

        }
    }
}