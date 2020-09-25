using System.Collections.Generic;
using MongoDB.Driver;
using NoSQL.Models;

namespace NoSQL.DataAccess
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}