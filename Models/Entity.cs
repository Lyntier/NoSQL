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
    [BsonIgnoreExtraElements]
    public abstract class Entity
    {
        /// <inheritdoc cref="IEntity"/>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public static implicit operator bool(Entity self) => self != null;
    }
}