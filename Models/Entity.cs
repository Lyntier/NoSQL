using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// ReSharper disable once InvalidXmlDocComment
/// <summary> Contains the different entities that are used in the solution. </summary>
namespace NoSQL.Models
{
    public interface IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
    }
    
    /// <summary>
    /// Represents an Entity within the application. Entities are classes
    /// which will be stored as JSON objects in the Mongo database.
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <summary> The unique identifier of an entity in the database. </summary>
        public string Id { get; set; }
    }
}