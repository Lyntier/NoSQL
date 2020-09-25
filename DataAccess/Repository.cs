using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using NoSQL.Models;
using NoSQL.Models.Util;

namespace NoSQL.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly IMongoCollection<TEntity> collection;

        // Dependency Injection 
        public Repository(ISettings settings)
        {
            var db = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            collection = db.GetCollection<TEntity>(GetCollectionName(typeof(TEntity)));
        }

        /// <summary> Returns the collection name that's specified in the type's BsonCollection attribute. </summary>
        /// <param name="entityType">The type whose collection name to retrieve</param>
        private protected string GetCollectionName(Type entityType)
        {
            return ((BsonCollectionAttribute) entityType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        #region Interface methods

        public TEntity Get(string id)
        {
            var objectId = new ObjectId(id);
            return collection.Find(e => e.Id == objectId).SingleOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return collection.AsQueryable();
        }

        public void Add(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}