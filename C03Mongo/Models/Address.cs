using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace C03Mongo.Models
{
    [BsonIgnoreExtraElements]
    internal class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string Municipality { get; set; } = string.Empty;
        public int? ZipCode { get; set; }
    }
}
