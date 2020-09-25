using System;

namespace NoSQL.Models.Util
{
    /// <summary>
    /// Allows for explicitly naming the plural of a model class.
    /// This makes it so that, for example, a table of multiple people
    /// can be called "people", and won't be automatically called "persons".
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute
    {
        public string CollectionName { get; }

        public BsonCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}