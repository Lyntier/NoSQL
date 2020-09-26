using System;

// ReSharper disable once InvalidXmlDocComment
/// <summary> Contains utility classes for the Models project. </summary>
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
        /// <summary> The plural name that a collection of a specific entity type should use. </summary>
        public string CollectionName { get; }

        public BsonCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}