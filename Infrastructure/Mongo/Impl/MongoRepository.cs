using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using Falcon.App.Core.Application.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Falcon.App.Infrastructure.Mongo.Impl
{
    [DefaultImplementation]
    public class MongoRepository<T> : IMongoRepository<T> where T : DomainBase
    {
        private static readonly string MongoDbConnectionString = ConfigurationManager.AppSettings["MongoDbConnectionString"];

        private static readonly string DefaultMongoDatabase = ConfigurationManager.AppSettings["DefaultMongoDatabase"];

        private readonly MongoCollection<T> _collection;
        private static string GetCollectionName()
        {
            var collectionName = (typeof(T)).Name;
            return collectionName;
        }

        public MongoRepository()
        {
            var mongoClient = new MongoClient(MongoDbConnectionString);
            var mongoDatabase = mongoClient.GetServer().GetDatabase(DefaultMongoDatabase);
            _collection = mongoDatabase.GetCollection<T>(GetCollectionName());
        }

        public T GetById(ObjectId id)
        {
            return _collection.FindOneByIdAs<T>(id);
        }

        public T Save(T entity)
        {
            _collection.Insert<T>(entity);
            return entity;
        }

        public void Save(IEnumerable<T> entities)
        {
            _collection.InsertBatch<T>(entities);
        }

        public T Update(T entity)
        {
            _collection.Save<T>(entity);
            return entity;
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _collection.Save<T>(entity);
            }
        }

        public void Delete(ObjectId id)
        {
            _collection.Remove(Query.EQ("_id", id));
        }

        public void Delete(T entity)
        {
            Delete(entity.Id);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            foreach (var entity in _collection.AsQueryable().Where(predicate))
            {
                Delete(entity.Id);
            }
        }

        public long Count()
        {
            return _collection.Count();
        }

        public long Count(Expression<Func<T, bool>> lambda)
        {
            IMongoQuery query = Query<T>.Where(lambda);
            return _collection.Count(query);
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _collection.AsQueryable().Any(predicate);
        }


        public IQueryable<T> Find(Expression<Func<T, bool>> lambda)
        {
            IMongoQuery query = Query<T>.Where(lambda);
            return _collection.Find(query).AsQueryable();

        }

        public IQueryable<T> Find(Expression<Func<T, bool>> lambda, int pageNumber, int pageSize, out int totalCount)
        {
            IMongoQuery query = Query<T>.Where(lambda);
            totalCount = (int)_collection.Find(query).Count();
            IMongoSortBy sortOrder = SortBy.Descending("Timestamp");
            return _collection.Find(query).SetSortOrder(sortOrder).SetSkip((pageNumber - 1) * pageSize).SetLimit(pageSize).AsQueryable();

        }
    }
}
