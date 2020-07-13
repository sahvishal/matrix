using System.Data;
using Falcon.App.Infrastructure.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Web.UnitTests.Infrastructure.Application
{
    public class RepositoryTesterBase
    {
        protected MockRepository _mocks;
        protected IPersistenceLayer _persistenceLayer;
        private IDataAccessAdapter _dataAccessAdapter;

        [SetUp]
        protected virtual void SetUp()
        {
            _mocks = new MockRepository();
            _persistenceLayer = _mocks.StrictMock<IPersistenceLayer>();
            _dataAccessAdapter = _mocks.StrictMock<IDataAccessAdapter>();
        }

        [TearDown]
        protected virtual void TearDown()
        {
            _mocks = null;
            _entitiesToReturn = null;
            _entitiesToReturnForSortExpression = null;
            _typedViewToReturn = null;
        }

        private IEntity2 _entityToFetch;
        private delegate bool FetchEntityDelegate(IEntity2 entity);
        private bool FetchEntity(IEntity2 entity)
        {
            if (_entityToFetch != null)
            {
                entity.Fields = _entityToFetch.Fields.Clone();
            }
            return true;
        }

        private IEntityCollection2 _entitiesToReturn;
        private delegate bool FetchEntityCollectionDelegate(IEntityCollection2 collection, IRelationPredicateBucket bucket);
        private bool FetchEntityCollection(IEntityCollection2 collection, IRelationPredicateBucket bucket)
        {
            if (_entitiesToReturn != null)
            {
                foreach (IEntity2 entity in _entitiesToReturn)
                {
                    collection.Add(entity);
                }
            }
            return true;
        }

        private IEntityCollection2 _entitiesToReturnForSortExpression;
        private delegate bool FetchEntityCollectionWithSortExpressionDelegate(IEntityCollection2 collection, 
            IRelationPredicateBucket bucket, int maxNumberOfItemsToReturn, ISortExpression sortExpression);
        private bool FetchEntityCollectionWithSortExpression(IEntityCollection2 collection, 
            IRelationPredicateBucket bucket, int maxNumberOfItemsToReturn, ISortExpression sortExpression)
        {
            if (_entitiesToReturnForSortExpression != null)
            {
                foreach (IEntity2 entity in _entitiesToReturnForSortExpression)
                {
                    collection.Add(entity);
                }
            }
            return true;
        }

        private ITypedView2 _typedViewToReturn;
        private delegate bool FetchTypedViewDelegate(ITypedView2 viewToFill, IRelationPredicateBucket bucket, bool allowDuplicates);
        private bool FetchTypedView(ITypedView2 viewToFill, IRelationPredicateBucket bucket, bool allowDuplicates)
        {
            if (_typedViewToReturn != null)
            {
                for (var i = 0; i < _typedViewToReturn.Count; i++)
                {
                    ((DataTable)viewToFill).Rows.Add();
                }
            }
            return true;
        }

        private delegate bool FetchLinqEntityCollectionDelegate(IEntityCollection2 collection,
            IRelationPredicateBucket bucket, int maxNumberOfItemsToReturn,
            ISortExpression sortExpression, IPrefetchPath2 prefetchPath,
            ExcludeIncludeFieldsList excludeIncludeFieldsList, int pageNumber, int pageSize);
        private bool FetchEntityCollection(IEntityCollection2 collection, IRelationPredicateBucket bucket,
            int maxNumberOfItemsToReturn, ISortExpression sortExpression, IPrefetchPath2 prefetchPath,
            ExcludeIncludeFieldsList excludeIncludeFieldsList, int pageNumber, int pageSize)
        {
            if (_entitiesToReturn != null)
            {
                foreach (IEntity2 entity in _entitiesToReturn)
                {
                    collection.Add(entity);
                }
            }
            return true;
        }

        protected void ExpectLinqFetchProjections()
        {
            Expect.Call(_dataAccessAdapter.FunctionMappings).Return(null);
            Expect.Call(() => _dataAccessAdapter.FetchProjection(null, null, null, null, 0, null, null, false, 0, 0))
                .IgnoreArguments();
        }

        protected void ExpectLinqFetchEntityCollection()
        {
            Expect.Call(_dataAccessAdapter.FunctionMappings).Return(new FunctionMappingStore());
            Expect.Call(() => _dataAccessAdapter.FetchEntityCollection(null, null, 0, null, null, null, 0, 0)).
                IgnoreArguments();
        }

        protected void ExpectLinqFetchEntityCollection(IEntityCollection2 entitiesToReturn)
        {
            _entitiesToReturn = entitiesToReturn;
            Expect.Call(_dataAccessAdapter.FunctionMappings).Return(new FunctionMappingStore());
            Expect.Call(() => _dataAccessAdapter.FetchEntityCollection(null, null, 0, null, null, null, 0, 0)).
                IgnoreArguments().Callback(new FetchLinqEntityCollectionDelegate(FetchEntityCollection));
        }

        protected void ExpectDeleteEntity(bool wasDeletionSuccessful)
        {
            Expect.Call(_dataAccessAdapter.DeleteEntity(null)).IgnoreArguments().Return(wasDeletionSuccessful);
        }

        protected void ExpectGetDataAccessAdapterAndDispose()
        {
            ExpectGetDataAccessAdapterAndDispose(1);
        }

        protected void ExpectGetDataAccessAdapterAndDispose(int numberOfTimesToExpect)
        {
            Expect.Call(_persistenceLayer.GetDataAccessAdapter()).Return(_dataAccessAdapter).Repeat.Times(numberOfTimesToExpect);
            Expect.Call(_dataAccessAdapter.Dispose).Repeat.Times(numberOfTimesToExpect);
        }

        protected void ExpectFetchEntityCollection()
        {
            Expect.Call(() => _dataAccessAdapter.FetchEntityCollection(null, null)).IgnoreArguments()
                .Callback(new FetchEntityCollectionDelegate(FetchEntityCollection));
        }

        protected void ExpectFetchEntityCollection(IEntityCollection2 entityCollectionToReturn)
        {
            _entitiesToReturn = entityCollectionToReturn;
            ExpectFetchEntityCollection();
        }

        protected void ExpectFetchEntityCollectionWithSortExpression()
        {
            Expect.Call(() => _dataAccessAdapter.FetchEntityCollection(null, null, 0, null)).IgnoreArguments()
                .Callback(new FetchEntityCollectionWithSortExpressionDelegate(FetchEntityCollectionWithSortExpression));
        }

        protected void ExpectFetchEntityCollectionWithSortExpression(IEntityCollection2 entityCollectionToReturn)
        {
            _entitiesToReturnForSortExpression = entityCollectionToReturn;
            ExpectFetchEntityCollectionWithSortExpression();
        }

        protected void ExpectFetchTypedView()
        {
            Expect.Call(() => _dataAccessAdapter.FetchTypedView(null, (IRelationPredicateBucket) null, true)).
                IgnoreArguments();
        }

        protected void ExpectFetchTypedView(ITypedView2 entityViewToReturn)
        {
            _typedViewToReturn = entityViewToReturn;
            Expect.Call(() => _dataAccessAdapter.FetchTypedView(null, (IRelationPredicateBucket)null, true)).IgnoreArguments()
                .Callback(new FetchTypedViewDelegate(FetchTypedView));
        }

        protected void ExpectFetchEntity(bool entityExists)
        {
            ExpectFetchEntity(entityExists, null);
        }

        protected void ExpectFetchEntityUsingUniqueConstraint(bool entityExists)
        {
            ExpectGetDataAccessAdapterAndDispose();
            Expect.Call(_dataAccessAdapter.FetchEntityUsingUniqueConstraint(null, null)).IgnoreArguments()
                .Return(entityExists);
        }

        protected void ExpectFetchEntity(bool entityExists, IEntity2 entityToFetch)
        {
            _entityToFetch = entityToFetch;
            Expect.Call(_dataAccessAdapter.FetchEntity(null)).IgnoreArguments().Return(entityExists)
                .Callback(new FetchEntityDelegate(FetchEntity));
        }

        protected void ExpectGetDbCount(int countToExpect)
        {
            Expect.Call(_dataAccessAdapter.GetDbCount((IEntityFields2)null, null)).IgnoreArguments()
                .Return(countToExpect);
        }

        protected void ExpectUpdateEntitiesDirectly(int numberOfEntitiesUpdated)
        {
            Expect.Call(_dataAccessAdapter.UpdateEntitiesDirectly(null, null)).IgnoreArguments()
                .Return(numberOfEntitiesUpdated);                
        }

        protected void ExpectSaveEntity(bool saveSuccessful)
        {
            ExpectSaveEntity(saveSuccessful, false);
        }

        protected void ExpectSaveEntity(bool saveSuccessful, bool expectWithRefetchAfterSaveParameter)
        {
            if (expectWithRefetchAfterSaveParameter)
            {
                Expect.Call(_dataAccessAdapter.SaveEntity(null, true)).IgnoreArguments().Return(saveSuccessful);
            }
            else
            {
                Expect.Call(_dataAccessAdapter.SaveEntity(null)).IgnoreArguments().Return(saveSuccessful);
            }
        }

        protected void ExpectSaveEntity(bool saveSuccessful, bool expectWithRefetchAfterSaveParameter, IEntity2 entityToSave)
        {
            if (expectWithRefetchAfterSaveParameter)
            {
                Expect.Call(_dataAccessAdapter.SaveEntity(entityToSave, true)).Return(saveSuccessful);
            }
            else
            {
                Expect.Call(_dataAccessAdapter.SaveEntity(entityToSave)).Return(saveSuccessful);
            }
        }

        protected void ExpectSaveEntityCollection(int numberOfEntitiesSaved)
        {
            Expect.Call(_dataAccessAdapter.SaveEntityCollection(null)).IgnoreArguments().Return(numberOfEntitiesSaved);
        }

        protected void ExpectTransaction(string transactionName, bool shouldExpectCommit)
        {
            Expect.Call(() => _dataAccessAdapter.StartTransaction(IsolationLevel.ReadCommitted, transactionName));
            if (shouldExpectCommit)
            {
                Expect.Call(_dataAccessAdapter.Commit);
            }
            else
            {
                Expect.Call(_dataAccessAdapter.Rollback);
            }
        }
    }
}