//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using Falcon.App.Core;
//using Falcon.App.Core.Application;
//using Falcon.App.Core.Application.Exceptions;
//using Falcon.App.Core.Deprecated;
//using Falcon.App.Core.Finance.Domain;
//using Falcon.App.Core.Finance.Impl;
//using Falcon.App.Core.Finance.Interfaces;
//using Falcon.App.Core.Impl;
//using Falcon.App.Core.Interfaces;
//using Falcon.App.Infrastructure.Application.Impl;
//using Falcon.App.Infrastructure.Interfaces;
//using Falcon.App.Infrastructure.Mappers;
//using Falcon.Data.Linq;
//using Falcon.App.Core.Extensions;
//using Falcon.Data.HelperClasses;
//using Falcon.Data.EntityClasses;
//using SD.LLBLGen.Pro.ORMSupportClasses;

//namespace Falcon.App.Infrastructure.Repositories
//{

using System;
using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Repositories;

public class MedicalVendorEarningRepository : PersistenceRepository, IMedicalVendorEarningRepository
{
    public List<MedicalVendorEarning> GetEarningsForMedicalVendorUser(long organizationRoleUserId, DateTime payPeriodStartDate, DateTime payPeriodEndDate)
    {
        throw new NotImplementedException();
    }

    public bool CustomerEventTestIdHasEarnings(long customerEventTestId)
    {
        throw new NotImplementedException();
    }

    public OrderedPair<int, decimal> GetNumberOfEarningsAndTotalAmountEarnedForUser(long organizationRoleUserId)
    {
        throw new NotImplementedException();
    }

    public OrderedPair<int, decimal> GetNumberOfEarningsAndTotalAmountEarnedForUser(long organizationRoleUserId, DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public void SaveMedicalVendorEarning(MedicalVendorEarning medicalVendorEarning)
    {
        throw new NotImplementedException();
    }

    public int GetEarningsNotInDateRanges(long organizationRoleUserId, List<OrderedPair<DateTime, DateTime>> dateRanges)
    {
        throw new NotImplementedException();
    }
}

//        private readonly IMapper<MedicalVendorEarning, MVEarningEntity> _mapper;
//        private readonly IValidator<MedicalVendorEarning> _validator;

//        public MedicalVendorEarningRepository()
//            : this(new SqlPersistenceLayer(),
//            new Validator<MedicalVendorEarning>(new MedicalVendorEarningValidationRuleFactory()),
//            new MedicalVendorEarningMapper(new DataRecorderMetaDataFactory()))
//        { }

//        public MedicalVendorEarningRepository(IPersistenceLayer persistenceLayer, 
//            IValidator<MedicalVendorEarning> validator, 
//            IMapper<MedicalVendorEarning, MVEarningEntity> mapper)
//            : base(persistenceLayer)
//        {
//            _validator = validator;
//            _mapper = mapper;
//        }

//        public List<MedicalVendorEarning> GetEarningsForMedicalVendorUser(long organizationRoleUserId,
//            DateTime payPeriodStartDate, DateTime payPeriodEndDate)
//        {
//            if (payPeriodStartDate > payPeriodEndDate)
//            {
//                throw new DateCannotExceedOtherDateException(payPeriodStartDate, payPeriodEndDate);
//            }

//            var medicalVendorEarningEntities = new EntityCollection<MVEarningEntity>();
//            var bucket = new RelationPredicateBucket(MVEarningFields.OrganizationRoleUserId ==
//                organizationRoleUserId);
//            bucket.PredicateExpression.Add(MVEarningFields.DateCreated >= payPeriodStartDate);
//            bucket.PredicateExpression.Add(MVEarningFields.DateCreated <= payPeriodEndDate);
//            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
//            {
//                myAdapter.FetchEntityCollection(medicalVendorEarningEntities, bucket);
//            }
//            return _mapper.MapMultiple(medicalVendorEarningEntities).ToList();
//        }

//        public bool CustomerEventTestIdHasEarnings(long customerEventTestId)
//        {
//            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
//            {
//                var linqMetaData = new LinqMetaData(myAdapter);
//                return (from medicalVendorEarnings in linqMetaData.MVEarning
//                        join mvUserEventTestLock in linqMetaData.MvuserEventTestLock on
//                            medicalVendorEarnings.MvuserEventTestLockId equals mvUserEventTestLock.
//                            MvuserEventTestLockId
//                        where mvUserEventTestLock.EventCustomerResultId == customerEventTestId
//                        select medicalVendorEarnings.MvearningId).Count() > 0;
//            }
//        }

//        // TODO: TEST more.
//        public OrderedPair<int, decimal> GetNumberOfEarningsAndTotalAmountEarnedForUser(long
//            organizationRoleUserId)
//        {
//            return GetNumberOfEarningsAndTotalAmountEarnedForUser(organizationRoleUserId, 
//                new DateTime(2000, 1, 1), DateTime.Today.AddDays(1));
//        }

//        public OrderedPair<int, decimal> GetNumberOfEarningsAndTotalAmountEarnedForUser(long organizationRoleUserId,
//            DateTime startDate, DateTime endDate)
//        {
//            var medicalVendorEarningStatistics = new DataTable("MedicalVendorEarningStatisticsDataTable");
//            IRelationPredicateBucket bucket = new RelationPredicateBucket
//                (MVEarningFields.OrganizationRoleUserId == organizationRoleUserId);
//            bucket.PredicateExpression.Add(MVEarningFields.DateCreated >= startDate);
//            bucket.PredicateExpression.Add(MVEarningFields.DateCreated <= endDate.GetEndOfDay());
//            var resultsetFields = new ResultsetFields(3);
//            resultsetFields.DefineField(MVEarningFields.MvuserAmountEarned, 0, 
//                "MedicalVendorAmountEarned", AggregateFunction.Sum);
//            resultsetFields.DefineField(MVEarningFields.MvuserAmountEarned, 1, 
//                "NumberOfEarnings", AggregateFunction.Count);
//            resultsetFields.DefineField(MVEarningFields.OrganizationRoleUserId, 2, 
//                "OrganizationRoleUserId");
//            var groupByCollection = new GroupByCollection(MVEarningFields.OrganizationRoleUserId);
//            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
//            {
//                myAdapter.FetchTypedList(resultsetFields, medicalVendorEarningStatistics, bucket, 0, null,
//                    false, groupByCollection);
//            }
//            int numberOfEarnings = 0;
//            decimal totalAmountEarned = 0m;
//            if (medicalVendorEarningStatistics.Rows.Count == 1)
//            {
//                numberOfEarnings = medicalVendorEarningStatistics.Rows[0].Field<int>("NumberOfEarnings");
//                totalAmountEarned = medicalVendorEarningStatistics.Rows[0].Field<decimal>
//                    ("MedicalVendorAmountEarned");
//            }
//            return new OrderedPair<int, decimal>(numberOfEarnings, totalAmountEarned);
//        }

//        public void SaveMedicalVendorEarning(MedicalVendorEarning medicalVendorEarning)
//        {
//            if (!_validator.IsValid(medicalVendorEarning))
//            {
//                throw new InvalidObjectException<MedicalVendorEarning>(_validator);
//            }

//            MVEarningEntity medicalVendorEarningEntity = _mapper.Map(medicalVendorEarning);
//            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
//            {
//                if (!myAdapter.SaveEntity(medicalVendorEarningEntity))
//                {
//                    throw new PersistenceFailureException();
//                }
//            }
//        }

//        public int GetEarningsNotInDateRanges(long organizationRoleUserId, 
//            List<OrderedPair<DateTime, DateTime>> dateRanges)
//        {
//            IRelationPredicateBucket bucket = new RelationPredicateBucket(MVEarningFields.
//                OrganizationRoleUserId == organizationRoleUserId);
//            foreach (var dateRange in dateRanges)
//            {
//                bucket.PredicateExpression.Add(!(MVEarningFields.DateCreated >= dateRange.FirstValue &
//                    MVEarningFields.DateCreated <= dateRange.SecondValue.GetEndOfDay()));
//            }
//            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
//            {
//                return myAdapter.GetDbCount(new EntityCollection<MVEarningEntity>(), bucket);
//            }
//        }
//    }
//}