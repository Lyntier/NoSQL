using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// ReSharper disable once InvalidXmlDocComment
/// <summary> Contains the different entities that are used in the solution. </summary>
namespace NoSQL.Models
{
    
    /// <summary>
    /// Represents an Entity within the application. Entities are classes
    /// which will be stored as JSON objects in the Mongo database.
    /// </summary>
    [Obsolete("The interface shouldn't be used as it lacks implicit comparisons. Use Entity directly instead.")]
    public interface IEntity
    {
        /// <summary>
        /// String representation of the ObjectID of an entity in the database.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
    }
    
    /// <inheritdoc cref="IEntity"/>
    public abstract class Entity : IEntity
    {
        
        /// <inheritdoc cref="IEntity"/>
        public string Id { get; set; }

        public static implicit operator bool(Entity self) => self != null;
    }
}