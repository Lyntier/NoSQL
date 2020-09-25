using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NoSQL.Models
{
    public interface IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }

    public abstract class Entity : IEntity
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}