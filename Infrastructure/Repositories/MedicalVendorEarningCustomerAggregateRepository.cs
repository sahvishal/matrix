using System;
using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.HelperClasses;
using Falcon.Data.TypedViewClasses;
using Falcon.App.Core.Extensions;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class MedicalVendorEarningCustomerAggregateRepository : PersistenceRepository, IMedicalVendorEarningCustomerAggregateRepository
    {
        private readonly IMedicalVendorEarningCustomerAggregateFactory _medicalVendorEarningCustomerAggregateFactory;

        public MedicalVendorEarningCustomerAggregateRepository()
        {
            _medicalVendorEarningCustomerAggregateFactory = new MedicalVendorEarningCustomerAggregateFactory();
        }

        public MedicalVendorEarningCustomerAggregateRepository(IPersistenceLayer persistenceLayer, 
            IMedicalVendorEarningCustomerAggregateFactory medicalVendorEarningCustomerAggregateFactory)
            : base(persistenceLayer)
        {
            _medicalVendorEarningCustomerAggregateFactory = medicalVendorEarningCustomerAggregateFactory;
        }

        private static IRelationPredicateBucket GetEarningCustomerAggregateFilter(long organizationRoleUserId,
            DateTime startDate, DateTime endDate)
        {
            IRelationPredicateBucket bucket = new RelationPredicateBucket
                (MedicalVendorEarningCustomerFields.OrganizationRoleUserId == organizationRoleUserId);
            bucket.PredicateExpression.Add(MedicalVendorEarningCustomerFields.EvaluationDate >= startDate);
            bucket.PredicateExpression.Add(MedicalVendorEarningCustomerFields.EvaluationDate <= endDate.GetEndOfDay());
            return bucket;
        }

        private static IRelationPredicateBucket GetEarningCustomerAggregateFilterForVendor(long medicalVendorId, 
            DateTime startDate, DateTime endDate)
        {
            IRelationPredicateBucket bucket = new RelationPredicateBucket
                (MedicalVendorEarningCustomerFields.OrganizationId == medicalVendorId);
            bucket.PredicateExpression.Add(MedicalVendorEarningCustomerFields.EvaluationDate >= startDate);
            bucket.PredicateExpression.Add(MedicalVendorEarningCustomerFields.EvaluationDate <= endDate.GetEndOfDay());
            return bucket;
        }

        private List<MedicalVendorEarningCustomerAggregate> FetchEarningCustomerAggregates(IRelationPredicateBucket bucket, 
            int pageSize, int pageNumber)
        {
            var medicalVendorEarningCustomerTypedView = new MedicalVendorEarningCustomerTypedView();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var sortExpression = new SortExpression(MedicalVendorEarningCustomerFields.EvaluationDate | SortOperator.Descending);
                myAdapter.FetchTypedView(new MedicalVendorEarningCustomerTypedView().GetFieldsInfo(),
                    medicalVendorEarningCustomerTypedView, bucket, pageSize, sortExpression, false, null, pageNumber, pageSize);
            }
            return _medicalVendorEarningCustomerAggregateFactory.CreateMedicalVendorEarningAggregates(medicalVendorEarningCustomerTypedView);
        }

        private int FetchNumberOfEarningCustomerAggregates(IRelationPredicateBucket bucket)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.GetDbCount(new MedicalVendorEarningCustomerTypedView().GetFieldsInfo(), bucket);
            }
        }

        // TODO: TEST (integration)
        public List<MedicalVendorEarningCustomerAggregate> GetEarningCustomerAggregatesNotInDateRanges
            (long organizationRoleUserId, List<OrderedPair<DateTime, DateTime>> dateRanges)
        {
            IRelationPredicateBucket bucket = new RelationPredicateBucket
                (MedicalVendorEarningCustomerFields.OrganizationRoleUserId == organizationRoleUserId);
            foreach (var dateRange in dateRanges)
            {
                bucket.PredicateExpression.Add(!(MedicalVendorEarningCustomerFields.EvaluationDate >= dateRange.FirstValue &
                    MedicalVendorEarningCustomerFields.EvaluationDate <= dateRange.SecondValue.GetEndOfDay()));
            }
            var medicalVendorEarningCustomerTypedView = new MedicalVendorEarningCustomerTypedView();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(new MedicalVendorEarningCustomerTypedView().GetFieldsInfo(),
                    medicalVendorEarningCustomerTypedView, bucket, false);
            }
            return _medicalVendorEarningCustomerAggregateFactory.CreateMedicalVendorEarningAggregates
                (medicalVendorEarningCustomerTypedView);
        }

        public List<MedicalVendorEarningCustomerAggregate> GetEarningCustomerAggregates(long organizationRoleUserId,
            DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            IRelationPredicateBucket bucket = GetEarningCustomerAggregateFilter(organizationRoleUserId, startDate, endDate);
            return FetchEarningCustomerAggregates(bucket, pageSize, pageNumber);
        }

        // TODO: TEST (integration)
        public int GetNumberofEarningCustomerAggregates(long organizationRoleUserId, DateTime startDate, DateTime endDate)
        {
            IRelationPredicateBucket bucket = GetEarningCustomerAggregateFilter(organizationRoleUserId, startDate, endDate);
            return FetchNumberOfEarningCustomerAggregates(bucket);
        }

        // TODO: TEST (integration)
        public List<MedicalVendorEarningCustomerAggregate> GetEarningCustomerAggregatesForVendor(long medicalVendorId, 
            DateTime startDate, DateTime endDate, int pageNumber, int pageSize)
        {
            IRelationPredicateBucket bucket = GetEarningCustomerAggregateFilterForVendor(medicalVendorId, startDate, endDate);
            return FetchEarningCustomerAggregates(bucket, pageSize, pageNumber);
        }

        // TODO: TEST (integration)
        public int GetNumberOfEarningCustomerAggregatesForVendor(long medicalVendorId, DateTime startDate, DateTime endDate)
        {
            IRelationPredicateBucket bucket = GetEarningCustomerAggregateFilterForVendor(medicalVendorId, startDate, endDate);
            return FetchNumberOfEarningCustomerAggregates(bucket);
        }
    }
}