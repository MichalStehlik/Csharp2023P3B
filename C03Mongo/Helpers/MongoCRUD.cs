using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C03Mongo.Helpers
{
    internal class MongoCRUD
    {
        private IMongoDatabase _database;
        public string Name { get; set; }

        public MongoCRUD(string name)
        {
            Name = name;
            var client = new MongoClient("mongodb://student:Educat1on@10.10.10.160:27017/?authSource=playground");
            _database = client.GetDatabase(name);
        }

        public void Create<T>(string collectionName, T document) 
        {
            var coll = _database.GetCollection<T>(collectionName);
            coll.InsertOne(document);
        }

        public T? Read<T>(string collectionName, Guid id)
        {
            var coll = _database.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", id);
            return coll.Find(filter).FirstOrDefault();
        }

        public List<T> List<T>(string collectionName)
        {
            var coll = _database.GetCollection<T>(collectionName);
            return coll.Find(new BsonDocument()).ToList();
        }

        public void Delete<T>(string table, Guid id)
        {
            var collection = _database.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }
        public void UpsertRecord<T>(string table, Guid id, T record)
        {
            var collection = _database.GetCollection<T>(table);
            var result = collection.ReplaceOne(
                new BsonDocument("_id", id),
                record,
                new ReplaceOptions { IsUpsert = true });
        }
    }
}
