using System.Collections.Generic;
using NoSQL.Models;

namespace NoSQL.DataAccess
{
    /// <summary>
    /// Allows for performing CRUD operations for the passed TEntity on the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type to create a repository for.</typeparam>
    /// <seealso cref="Entity"/>
    public interface IRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Returns the entity with the given ID from the database, or <code>null</code> if none was found.
        /// </summary>
        TEntity Get(string id);
        
        /// <summary>
        /// Returns all entities of the corresponding type from the database.
        /// </summary>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Adds the given entity to the database, generating an ID for it.
        /// </summary>
        void Add(TEntity entity);
        
        /// <summary>
        /// Replaces the values of the current entity in the database with those stored in memory.
        /// </summary>
        void Update(TEntity entity);
        
        /// <summary>
        /// Removes the given entity from the database if it exists.
        /// </summary>
        void Delete(TEntity entity);

    }
}