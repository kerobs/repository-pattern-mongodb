using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

using Web.Core.Interfaces;
using Web.Core.Helpers;

namespace Web.Persistence.Repositories
{
    public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private static string _connectionString = "mongodb://kerobs:digital5418@ds261745.mlab.com:61745/kerobs_mdb";
        //ConfigurationManager.ConnectionStrings["db"].ConnectionString;
       



        private static MongoClient _client = new MongoClient(_connectionString);
        private string _collectionName;
        protected IMongoDatabase _db;

        public MongoRepository(string collectionName)
        {
            _collectionName = collectionName;
            _db = _client.GetDatabase(MongoUrl.Create(_connectionString).DatabaseName);
        }


        protected IMongoCollection<TEntity> _collection
        {
            get { return _db.GetCollection<TEntity>(_collectionName); }
            set { _collection = value; }
        }

        public IQueryable<TEntity> Query
        {
            get { return _collection.AsQueryable<TEntity>(); }
            set { Query = value; }
        }

        public bool Add(TEntity entity)
        {
            _collection.InsertOne(entity);
            return true;
        }

        public int AddRange(IEnumerable<TEntity> entities)
        {
            _collection.InsertMany(entities);
            return entities.Count();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll(int page, int pageSize)
        {
            return PagingExtensions.Page(Query, page, pageSize);
        }

        public int Remove(Expression<Func<TEntity, bool>> expression)
        {
            int count = 0;
            var items = Query.Where(expression);
            foreach (TEntity item in items)
            {
                if (Remove(item))
                {
                    count++;
                }
            }

            return count;
        }

        public bool Remove(TEntity entity)
        {
            ObjectId id = new ObjectId(typeof(TEntity).GetProperty("Id").GetValue(entity, null).ToString());
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            // Remove the object.
            var result = _collection.DeleteOne(filter);
            return result.DeletedCount == 1;
        }

        public void RemoveAll()
        {
            _db.DropCollection(typeof(TEntity).Name);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return Query.Where(expression).SingleOrDefault();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Query;
        }
    }
}