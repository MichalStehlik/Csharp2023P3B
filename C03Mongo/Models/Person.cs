using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C03Mongo.Models
{
    internal class Person
    {
        public Guid Id { get; set; }
        public string? Firstname { get; set; }
        [BsonElement("Home")]
        public Address HomeAddress { get; set;}
    }
}
