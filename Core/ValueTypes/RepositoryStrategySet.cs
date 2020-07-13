using System;
using System.Collections.Generic;
using Falcon.App.Core.Application;

namespace Falcon.App.Core.ValueTypes
{
    public class RepositoryStrategySet<T>
    {
        public ICollection<IPrePersistenceStrategy<T>> PrePersistenceStrategies { get; private set; }
        public ICollection<IPostPersistenceStrategy<T>> PostPersistenceStrategies { get; private set; }                

        public ICollection<IPostFetchStrategy<T>> PostFetchStrategies { get; private set; }
        public ICollection<IPostFetchStrategy<IEnumerable<T>>> PostFetchCollectionStrategies { get; private set;}

        public RepositoryStrategySet()
        {
            PrePersistenceStrategies = new List<IPrePersistenceStrategy<T>>();            
            PostFetchStrategies = new List<IPostFetchStrategy<T>>();
            PostPersistenceStrategies = new List<IPostPersistenceStrategy<T>>();
            PostFetchCollectionStrategies = new List<IPostFetchStrategy<IEnumerable<T>>>();
        }

        private RepositoryStrategySet<T> AppendCollectionChain<U>(ICollection<U> collection, U strategy) where U : class
        {
            if (strategy == null)
            {
                throw new ArgumentNullException(typeof(U).Name);
            }
            collection.Add(strategy);
            return this;
        }

        public RepositoryStrategySet<T> WithPrePersistenceStrategy(IPrePersistenceStrategy<T> prePersistenceStrategy)
        {
            return AppendCollectionChain(PrePersistenceStrategies, prePersistenceStrategy);
        }

        public RepositoryStrategySet<T> WithPostPersistenceStrategy(IPostPersistenceStrategy<T> postPersistenceStrategy)
        {
            return AppendCollectionChain(PostPersistenceStrategies, postPersistenceStrategy);
        }

        public RepositoryStrategySet<T> WithPostFetchStrategy(IPostFetchStrategy<T> postFetchStrategy)
        {
            return AppendCollectionChain(PostFetchStrategies, postFetchStrategy);
        }

        public RepositoryStrategySet<T> WithPostFetchCollectionStrategy(IPostFetchStrategy<IEnumerable<T>> postFetchCollectionStrategy)
        {
            return AppendCollectionChain(PostFetchCollectionStrategies, postFetchCollectionStrategy);
        }
    }
}