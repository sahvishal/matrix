using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Impl;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.Extensions;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class SourceCodeRepository : PersistenceRepository, ISourceCodeRepository
    {
        private readonly IMapper<SourceCode, CouponsEntity> _mapper;

        public SourceCodeRepository()
            : this(new SourceCodeMapper())
        { }

        public SourceCodeRepository(IMapper<SourceCode, CouponsEntity> mapper)
        {
            _mapper = mapper;
        }

        public SourceCode GetSourceCodeById(long sourceCodeId)
        {
            var sourceCodeEntity = new CouponsEntity(sourceCodeId);
            IPrefetchPath2 prefetchPath = new PrefetchPath2((int)EntityType.CouponsEntity)
                                              {
                                                  CouponsEntity.PrefetchPathCouponSignUpMode,
                                                  CouponsEntity.PrefetchPathPackageSourceCodeDiscount,
                                                  CouponsEntity.PrefetchPathTestSourceCodeDiscount,
                                                  CouponsEntity.PrefetchPathProductSourceCodeDiscount,
                                                  CouponsEntity.PrefetchPathShippingOptionSourceCodeDiscount,
                                                  CouponsEntity.PrefetchPathEventCoupons
                                              };

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.FetchEntity(sourceCodeEntity, prefetchPath))
                {
                    throw new ObjectNotFoundInPersistenceException<SourceCode>(sourceCodeId);
                }
            }
            return _mapper.Map(sourceCodeEntity);
        }

        public IEnumerable<SourceCode> GetSourceCodeByIds(long[] sourceCodeIds)
        {
            var sourceCodeEntities = new EntityCollection<CouponsEntity>();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(sourceCodeEntities,
                                              new RelationPredicateBucket(CouponsFields.CouponId == sourceCodeIds));
                if (sourceCodeEntities.Count < 1)
                {
                    return null;
                }
            }
            return _mapper.MapMultiple(sourceCodeEntities);
        }

        public SourceCode GetSourceCodeByCode(string sourceCode)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var sourceCodeEntity =
                    linqMetaData.Coupons.Where(c => c.CouponCode == sourceCode && c.IsActive).WithPath(path => path.Prefetch(ce => ce.CouponSignUpMode)
                                                                                                                .Prefetch(ce => ce.PackageSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.TestSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.ProductSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.ShippingOptionSourceCodeDiscount)
                                                                                                                .Prefetch(ce=>ce.EventCoupons)).SingleOrDefault();

                if (sourceCodeEntity == null) return null;

                return _mapper.Map(sourceCodeEntity);
            }
        }

        public SourceCode SaveSourceCode(SourceCode sourceCode)
        {
            var sourceCodeEntity = _mapper.Map(sourceCode);
            
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                using (var scope = new TransactionScope())
                {
                    
                    if (sourceCode.Id > 0)
                        adapter.UpdateEntitiesDirectly(sourceCodeEntity,
                                                       new RelationPredicateBucket(CouponsFields.CouponId == sourceCode.Id));
                    else
                    {
                        if (!adapter.SaveEntity(sourceCodeEntity, true, true))
                        {
                            throw new PersistenceFailureException();
                        }
                    }

                    var sourceCodeSaved = _mapper.Map(sourceCodeEntity);
                    if (sourceCode.Id > 0)
                    {
                        DeletePackageSourceCodeDiscounts(sourceCode.Id);
                        DeleteTestSourceCodeDiscounts(sourceCode.Id);
                        DeleteSourceCodeSignUpModes(sourceCode.Id);
                        DeleteShippingSourceCodeDiscounts(sourceCode.Id);
                        DeleteProductSourceCodeDiscounts(sourceCode.Id);
                        DeleteEventCoupons(sourceCode.Id);
                    }

                    if (sourceCode.PackageDiscounts != null && sourceCode.PackageDiscounts.Count() > 0)
                    {
                        sourceCodeSaved.PackageDiscounts = SavePackageSourceCodeDiscounts(sourceCodeSaved.Id,
                                                                                          sourceCode.PackageDiscounts);
                    }

                    if (sourceCode.TestDiscounts != null && sourceCode.TestDiscounts.Count() > 0)
                    {
                        sourceCodeSaved.TestDiscounts = SaveTestSourceCodeDiscounts(sourceCodeSaved.Id,
                                                                                    sourceCode.TestDiscounts);
                    }

                    if (sourceCode.ProductDiscounts != null && sourceCode.ProductDiscounts.Count() > 0)
                    {
                        sourceCodeSaved.ProductDiscounts = SaveProductSourceCodeDiscounts(sourceCodeSaved.Id,
                                                                                          sourceCode.ProductDiscounts);
                    }

                    if (sourceCode.ShippingDiscounts != null && sourceCode.ShippingDiscounts.Count() > 0)
                    {
                        sourceCodeSaved.ShippingDiscounts = SaveShippingSourceCodeDiscounts(sourceCodeSaved.Id,
                                                                                            sourceCode.ShippingDiscounts);
                    }

                    if (sourceCode.SelectedSignUpModes != null && sourceCode.SelectedSignUpModes.Count() > 0)
                    {
                        SaveSourceCodeSignupMode(sourceCode.SelectedSignUpModes, sourceCodeSaved.Id);
                        sourceCodeSaved.SelectedSignUpModes = sourceCode.SelectedSignUpModes;
                    }
                    if(sourceCode.EventIds!=null && sourceCode.EventIds.Count()>0)
                    {
                        SaveEventCoupons(sourceCodeSaved.Id, sourceCode.EventIds);
                    }
                    scope.Complete();
                    return sourceCodeSaved;
                }
            }
        }

        public bool ValidateSourceCode(string sourceCode)
        {
            IRelationPredicateBucket bucket =
                new RelationPredicateBucket(CouponsFields.CouponCode == sourceCode);
            var coupons = new EntityCollection<CouponsEntity>();

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(coupons, bucket);
            }
            return coupons.IsEmpty();
        }

        public bool ValidateSourceCode(string sourceCode, long id)
        {
            IRelationPredicateBucket bucket =
                new RelationPredicateBucket(CouponsFields.CouponCode == sourceCode);
            bucket.PredicateExpression.AddWithAnd(CouponsFields.CouponId != id);

            var coupons = new EntityCollection<CouponsEntity>();

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(coupons, bucket);
            }
            return coupons.IsEmpty();
        }

        public bool IsSourceCodeAWorkshopSourceCode(string sourceCodeString)
        {
            var sourceCode = GetSourceCodeByCode(sourceCodeString);
            if (sourceCode == null) return false;

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var resultRecords = linqMetaData.Afcampaign.Where(campaign => sourceCode.Id == campaign.PromoCodeId).
                    Join(linqMetaData.SeminarCampaignDetails,
                        campaign => campaign.CampaignId, seminarCampaign => seminarCampaign.CampaignId,
                        (campaign, seminarCampaign) => campaign).ToList();

                if (!resultRecords.IsNullOrEmpty())
                    return true;
            }
            return false;
        }

        private void DeletePackageSourceCodeDiscounts(long sourceCodeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket =
                    new RelationPredicateBucket(PackageSourceCodeDiscountFields.SourceCodeId == sourceCodeId);
                adapter.DeleteEntitiesDirectly(typeof(PackageSourceCodeDiscountEntity), relationPredicateBucket);
            }
        }

        private void DeleteTestSourceCodeDiscounts(long sourceCodeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket =
                    new RelationPredicateBucket(TestSourceCodeDiscountFields.SourceCodeId == sourceCodeId);
                adapter.DeleteEntitiesDirectly(typeof(TestSourceCodeDiscountEntity), relationPredicateBucket);
            }
        }

        private void DeleteShippingSourceCodeDiscounts(long sourceCodeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket =
                    new RelationPredicateBucket(ShippingOptionSourceCodeDiscountFields.SourceCodeId == sourceCodeId);
                adapter.DeleteEntitiesDirectly(typeof(ShippingOptionSourceCodeDiscountEntity), relationPredicateBucket);
            }
        }

        private void DeleteProductSourceCodeDiscounts(long sourceCodeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket =
                    new RelationPredicateBucket(ProductSourceCodeDiscountFields.SourceCodeId == sourceCodeId);
                adapter.DeleteEntitiesDirectly(typeof(ProductSourceCodeDiscountEntity), relationPredicateBucket);
            }
        }

        private void DeleteSourceCodeSignUpModes(long sourceCodeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket =
                    new RelationPredicateBucket(CouponSignUpModeFields.CouponId == sourceCodeId);
                adapter.DeleteEntitiesDirectly(typeof(CouponSignUpModeEntity), relationPredicateBucket);
            }
        }

        private void DeleteEventCoupons(long sourceCodeId)
        {
            using(var adapter=PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(EventCouponsFields.CouponId == sourceCodeId);
                adapter.DeleteEntitiesDirectly(typeof (EventCouponsEntity), relationPredicateBucket);
            }
        }

        private IEnumerable<SourceCodeItemWiseDiscount> SavePackageSourceCodeDiscounts(long sourceCodeId, IEnumerable<SourceCodeItemWiseDiscount> packageDiscounts)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities =
                    packageDiscounts.Select(
                        pd =>
                        new PackageSourceCodeDiscountEntity
                            {
                                SourceCodeId = sourceCodeId,
                                PackageId = pd.Id,
                                Discount = pd.DiscountAmount,
                                IsPercentage = (pd.DiscountValueType == DiscountValueType.Percent ? true : false),
                                IsNew = true
                            }).ToArray();

                var entityCollection = new EntityCollection<PackageSourceCodeDiscountEntity>();
                entityCollection.AddRange(entities);
                adapter.SaveEntityCollection(entityCollection, true, false);
                return Mapper.Map<IEnumerable<PackageSourceCodeDiscountEntity>, IEnumerable<SourceCodeItemWiseDiscount>>(entities);
            }
        }

        private IEnumerable<SourceCodeItemWiseDiscount> SaveTestSourceCodeDiscounts(long sourceCodeId, IEnumerable<SourceCodeItemWiseDiscount> testDiscounts)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = testDiscounts.Select(td => new TestSourceCodeDiscountEntity
                                                              {
                                                                  SourceCodeId = sourceCodeId,
                                                                  TestId = td.Id,
                                                                  Discount = td.DiscountAmount,
                                                                  IsPercentage =
                                                                      (td.DiscountValueType == DiscountValueType.Percent
                                                                           ? true
                                                                           : false),
                                                                  IsNew = true
                                                              }).ToArray();
                var entityCollection = new EntityCollection<TestSourceCodeDiscountEntity>();
                entityCollection.AddRange(entities);
                adapter.SaveEntityCollection(entityCollection, true, false);

                return Mapper.Map<IEnumerable<TestSourceCodeDiscountEntity>, IEnumerable<SourceCodeItemWiseDiscount>>(entities);
            }
        }

        private IEnumerable<SourceCodeItemWiseDiscount> SaveShippingSourceCodeDiscounts(long sourceCodeId, IEnumerable<SourceCodeItemWiseDiscount> shippingDiscounts)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = shippingDiscounts.Select(td => new ShippingOptionSourceCodeDiscountEntity
                {
                    SourceCodeId = sourceCodeId,
                    ShippingOptionId = td.Id,
                    Discount = td.DiscountAmount,
                    IsPercentage = (td.DiscountValueType == DiscountValueType.Percent ? true : false),
                    IsNew = true
                }).ToArray();

                var entityCollection = new EntityCollection<ShippingOptionSourceCodeDiscountEntity>();
                entityCollection.AddRange(entities);
                adapter.SaveEntityCollection(entityCollection, true, false);

                return Mapper.Map<IEnumerable<ShippingOptionSourceCodeDiscountEntity>, IEnumerable<SourceCodeItemWiseDiscount>>(entities);
            }
        }

        private IEnumerable<SourceCodeItemWiseDiscount> SaveProductSourceCodeDiscounts(long sourceCodeId, IEnumerable<SourceCodeItemWiseDiscount> shippingDiscounts)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = shippingDiscounts.Select(td => new ProductSourceCodeDiscountEntity
                {
                    SourceCodeId = sourceCodeId,
                    ProductId = td.Id,
                    Discount = td.DiscountAmount,
                    IsPercentage = (td.DiscountValueType == DiscountValueType.Percent ? true : false),
                    IsNew = true
                }).ToArray();

                var entityCollection = new EntityCollection<ProductSourceCodeDiscountEntity>();
                entityCollection.AddRange(entities);
                adapter.SaveEntityCollection(entityCollection, true, false);

                return Mapper.Map<IEnumerable<ProductSourceCodeDiscountEntity>, IEnumerable<SourceCodeItemWiseDiscount>>(entities);
            }
        }

        private void SaveEventCoupons(long sourceCodeId, IEnumerable<long> eventIds)
        {
            using (var adapter =PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = eventIds.Select(e => new EventCouponsEntity
                                                        {
                                                            CouponId = sourceCodeId,
                                                            EventId = e
                                                        }).ToArray();
                var entityCollection = new EntityCollection<EventCouponsEntity>();
                entityCollection.AddRange(entities);
                adapter.SaveEntityCollection(entityCollection);
            }
        }

        public void SaveSourceCodeSignupMode(IEnumerable<SignUpMode> signUpModes, long sourceCodeId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities =
                    signUpModes.Select(
                        sm => new CouponSignUpModeEntity { CouponId = sourceCodeId, SignUpMode = (byte)sm }).ToArray();

                var entityCollection = new EntityCollection<CouponSignUpModeEntity>();
                entityCollection.AddRange(entities);
                adapter.SaveEntityCollection(entityCollection, true, false);
            }
        }

        public IEnumerable<SourceCode> GetbyFilter(SourceCodeListModelFilter filter, int pageNumber, int pageSize, out long totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (filter == null)
                {
                    var entities =
                        linqMetaData.Coupons.OrderByDescending(c => c.DateModified ?? c.DateCreated).TakePage(pageNumber, pageSize).WithPath(path => path.Prefetch(ce => ce.CouponSignUpMode)
                                                                                                                .Prefetch(ce => ce.PackageSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.TestSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.ProductSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.ShippingOptionSourceCodeDiscount)).ToArray();

                    totalRecords = linqMetaData.Coupons.Count();

                    return _mapper.MapMultiple(entities);
                }
                else
                {
                    var query = from c in linqMetaData.Coupons select c;
                    if (!string.IsNullOrEmpty(filter.SourceCodeName))
                    {
                        query = from c in query where c.CouponCode.Contains(filter.SourceCodeName) select c;
                    }

                    if (filter.SourceCodeTypeId > 0)
                        query = from c in query where c.CouponTypeId == filter.SourceCodeTypeId select c;

                    totalRecords = query.Count();

                    var entities =
                        query.OrderByDescending(c => c.DateModified ?? c.DateCreated).TakePage(pageNumber, pageSize).WithPath(path => path.Prefetch(ce => ce.CouponSignUpMode)
                                                                                                                .Prefetch(ce => ce.PackageSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.TestSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.ProductSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.ShippingOptionSourceCodeDiscount)).ToArray();

                    return _mapper.MapMultiple(entities);
                }
            }
        }

        public void SetSourceCodeIsActiveState(long id, bool isActive)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new CouponsEntity { IsActive = isActive },
                                               new RelationPredicateBucket(CouponsFields.CouponId == id));
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetCouponTypeIdNamepair()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ct in linqMetaData.CouponType
                        where ct.IsActive
                        select new OrderedPair<long, string>(ct.CouponTypeId, ct.Name)).ToArray();
            }
        }

        public IEnumerable<SourceCode> SearchSourceCodeByName(string sourceCode)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var sourceCodeEntities =
                    linqMetaData.Coupons.Where(c => c.CouponCode.Contains(sourceCode)  && c.IsActive).WithPath(path => path.Prefetch(ce => ce.CouponSignUpMode)
                                                                                                                .Prefetch(ce => ce.PackageSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.TestSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.ProductSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.ShippingOptionSourceCodeDiscount)
                                                                                                                .Prefetch(ce => ce.EventCoupons)).ToArray();
                

                return _mapper.MapMultiple(sourceCodeEntities);

            }
        }
    }
}