using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.App.Core.Extensions;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Data;
using Falcon.Data;

namespace Falcon.App.Infrastructure.Repositories
{
    public class MedicalVendorInvoiceStatisticRepository : PersistenceRepository, IMedicalVendorInvoiceStatisticRepository
    {
        private readonly IMedicalVendorInvoiceStatisticFactory _medicalVendorInvoiceStatisticFactory;

        public MedicalVendorInvoiceStatisticRepository()
        {
            _medicalVendorInvoiceStatisticFactory = new MedicalVendorInvoiceStatisticFactory();
        }

        private List<MedicalVendorInvoiceStatistic> FetchInvoiceStatistics(IRelationPredicateBucket bucket)
        {
            var physicianInvoiceEntities = new EntityCollection<PhysicianInvoiceEntity>();
            var medicalVendorInvoiceItemStatistics = new DataTable("MedicalVendorInvoiceItemStatisticsDataTable");
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IPrefetchPath2 path = new PrefetchPath2(EntityType.PhysicianInvoiceEntity);
                path.Add(PhysicianInvoiceEntity.PrefetchPathPhysicianProfile);
                myAdapter.FetchEntityCollection(physicianInvoiceEntities, bucket, path);

                long[] medicalVendorInvoiceIds = physicianInvoiceEntities.Select(i => i.PhysicianInvoiceId).ToArray();
                if (!medicalVendorInvoiceIds.IsEmpty())
                {
                    IRelationPredicateBucket medicalVendorInvoiceItemBucket = new RelationPredicateBucket
                        (PhysicianInvoiceItemFields.PhysicianInvoiceId == medicalVendorInvoiceIds);
                    
                    OrderedPair<ResultsetFields, GroupByCollection> resultsetFieldsAndGroupByCollection = _medicalVendorInvoiceStatisticFactory.
                        CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClause();

                    myAdapter.FetchTypedList(resultsetFieldsAndGroupByCollection.FirstValue, medicalVendorInvoiceItemStatistics, 
                        medicalVendorInvoiceItemBucket, 0, null, true, resultsetFieldsAndGroupByCollection.SecondValue); 
                }
            }
            return _medicalVendorInvoiceStatisticFactory.CreateMedicalVendorInvoiceStatistics(physicianInvoiceEntities,
                medicalVendorInvoiceItemStatistics);
        }

        private static IRelationPredicateBucket GetRelationPredicateBucket(long organizationRoleUserId, DateTime startDate, DateTime endDate)
        {
            IRelationPredicateBucket bucket = new RelationPredicateBucket(PhysicianInvoiceFields.PhysicianId == organizationRoleUserId);
            bucket.PredicateExpression.Add(PhysicianInvoiceFields.DateGenerated >= startDate &
                PhysicianInvoiceFields.DateGenerated <= endDate.GetEndOfDay());
            return bucket;
        }

        private static IRelationPredicateBucket GetRelationPredicateBucketForVendor(long medicalVendorId, DateTime startDate, DateTime endDate)
        {
            IRelationPredicateBucket bucket = new RelationPredicateBucket();
            bucket.Relations.Add(PhysicianInvoiceEntity.Relations.PhysicianProfileEntityUsingPhysicianId);
            bucket.PredicateExpression.Add(OrganizationRoleUserFields.OrganizationId == medicalVendorId);
            bucket.PredicateExpression.Add(PhysicianInvoiceFields.DateGenerated >= startDate &
                PhysicianInvoiceFields.DateGenerated <= endDate.GetEndOfDay());
            return bucket;
        }

        private List<MedicalVendorInvoiceStatistic> FetchPagedInvoiceStatistics(IRelationPredicateBucket bucket, int pageSize, int pageNumber)
        {
            var medicalVendorInvoiceEntities = new EntityCollection<PhysicianInvoiceEntity>();
            var medicalVendorInvoiceItemStatistics = new DataTable("MedicalVendorInvoiceItemStatisticsDataTable");
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IPrefetchPath2 path = new PrefetchPath2(EntityType.PhysicianInvoiceEntity);
                path.Add(PhysicianInvoiceEntity.PrefetchPathPhysicianProfile);
                
                myAdapter.FetchEntityCollection(medicalVendorInvoiceEntities, bucket,  pageSize, null, path,
                                                pageNumber, pageSize);

                long[] medicalVendorInvoiceIds = medicalVendorInvoiceEntities.Select(i => i.PhysicianInvoiceId).ToArray();
                IRelationPredicateBucket medicalVendorInvoiceItemBucket = new RelationPredicateBucket
                    (PhysicianInvoiceItemFields.PhysicianInvoiceId == medicalVendorInvoiceIds);
                OrderedPair<ResultsetFields, GroupByCollection> resultsetFieldsAndGroupByCollection = _medicalVendorInvoiceStatisticFactory.
                    CreateMedicalVendorInvoiceStatisticFieldsAndGroupByClause();
                myAdapter.FetchTypedList(resultsetFieldsAndGroupByCollection.FirstValue, medicalVendorInvoiceItemStatistics,
                    medicalVendorInvoiceItemBucket, 0, null, true, resultsetFieldsAndGroupByCollection.SecondValue);
            }
            return _medicalVendorInvoiceStatisticFactory.CreateMedicalVendorInvoiceStatistics(medicalVendorInvoiceEntities,
                medicalVendorInvoiceItemStatistics);
        }

        private int FetchNumberOfInvoiceStatistics(IRelationPredicateBucket bucket)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.GetDbCount(new EntityCollection<PhysicianInvoiceEntity>(), bucket);
            }
        }

        public MedicalVendorInvoiceStatistic GetInvoiceStatistic(long medicalVendorInvoiceId)
        {
            IRelationPredicateBucket bucket = new RelationPredicateBucket(PhysicianInvoiceFields.PhysicianInvoiceId == medicalVendorInvoiceId);
            return FetchInvoiceStatistics(bucket).Single();
        }

        public List<MedicalVendorInvoiceStatistic> GetAllInvoiceStatistics()
        {
            return FetchInvoiceStatistics(null);
        }

        public List<MedicalVendorInvoiceStatistic> GetInvoiceStatisticsByPaymentStatus(PaymentStatus paymentStatus)
        {
            IRelationPredicateBucket bucket = new RelationPredicateBucket(PhysicianInvoiceFields.PaymentStatus == (byte)paymentStatus);
            return FetchInvoiceStatistics(bucket);
        }

        public List<MedicalVendorInvoiceStatistic> GetInvoiceStatisticsForMedicalVendorUser(long medicalVendorUserId, 
            PaymentStatus paymentStatus)
        {
            IRelationPredicateBucket bucket = new RelationPredicateBucket(PhysicianInvoiceFields.PhysicianId == medicalVendorUserId);
            bucket.PredicateExpression.Add(PhysicianInvoiceFields.PaymentStatus == paymentStatus);
            return FetchInvoiceStatistics(bucket);
        }

        public List<MedicalVendorInvoiceStatistic> GetInvoiceStatisticsForMedicalVendorUser(long organizationRoleUserId, 
            DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            IRelationPredicateBucket bucket = GetRelationPredicateBucket(organizationRoleUserId, startDate, endDate);
            return FetchPagedInvoiceStatistics(bucket, pageSize, pageNumber);
        }

        public List<MedicalVendorInvoiceStatistic> GetInvoiceStatisticsForMedicalVendor(long medicalVendorId, 
            DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            IRelationPredicateBucket bucket = GetRelationPredicateBucketForVendor(medicalVendorId, startDate, endDate);
            return FetchPagedInvoiceStatistics(bucket, pageSize, pageNumber);
        }

        public int GetNumberOfInvoiceStatisticsForMedicalVendorUser(long organizationRoleUserId, DateTime startDate, DateTime endDate)
        {
            IRelationPredicateBucket bucket = GetRelationPredicateBucket(organizationRoleUserId, startDate, endDate);
            return FetchNumberOfInvoiceStatistics(bucket);
        }

        public int GetNumberOfInvoiceStatisticsForMedicalVendor(long medicalVendorId, DateTime startDate, DateTime endDate)
        {
            IRelationPredicateBucket bucket = GetRelationPredicateBucketForVendor(medicalVendorId, startDate, endDate);
            return FetchNumberOfInvoiceStatistics(bucket);
        }
    }
}