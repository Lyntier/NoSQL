using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.Identity.Mongo.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using NoSQL.Models;
using NoSQL.Models.Util;

namespace NoSQL.DataAccess
{
    /// <inheritdoc cref="IRepository{TEntity}"/>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly IMongoCollection<TEntity> _collection;

        // Dependency Injection 
        public Repository(ISettings settings)
        {
            var db = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = db.GetCollection<TEntity>(GetCollectionName(typeof(TEntity)));
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

        /// <inheritdoc cref="IRepository{TEntity}"/>
        public TEntity Get(string id)
        {
            return _collection.Find(e => e.Id.Equals(id)).SingleOrDefault();
        }

        /// <inheritdoc cref="IRepository{TEntity}"/>
        public IEnumerable<TEntity> GetAll()
        {
            return _collection.AsQueryable();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> filter)
        {
            return GetAll()
                .Where(filter);
        }

        public TEntity FindOne(Func<TEntity, bool> filter)
        {
            return Find(filter)
                .FirstOrDefault();
        }

        /// <inheritdoc cref="IRepository{TEntity}"/>
        public void Add(TEntity entity)
        {
            // For some reason, ID isn't set on insert, so if it has to be set it'll be set here.
            entity.Id ??= ObjectId.GenerateNewId().ToString();
            _collection.InsertOne(entity);
        }

        /// <inheritdoc cref="IRepository{TEntity}"/>
        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IRepository{TEntity}"/>
        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}