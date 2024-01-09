using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace C03Mongo.Models
{
    internal class Person
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        [BsonElement("Home")]
        public Address HomeAddress { get; set;}
    }
}
