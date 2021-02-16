using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Models
{
    public class MongoDbContext : IDbContext
    {
        private static IMongoDatabase db;
        private static IDatabaseConfiguration _dbConfig;
        public MongoDbContext(IDatabaseConfiguration dbConfig)
        {
            _dbConfig = dbConfig;
            var client = new MongoClient(dbConfig.Server);
            db = client.GetDatabase(_dbConfig.Database);
        }

        public async Task InsertRecordAsync<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            await Task.FromResult(collection.InsertOneAsync(record));
        }
        public async Task<IEnumerable<T>> LoadRecordsAsync<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return await collection.Find(new BsonDocument()).ToListAsync();
        }
        public async Task<T> LoadRecordByIdAsync<T>(string table, string id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var record = await collection.FindAsync(filter);
            return record.FirstOrDefault();
        }
        public async Task UpsertRecordAsync<T>(string table, string id, T record)
        {
            var collection = db.GetCollection<T>(table);
            var result = await collection.ReplaceOneAsync(
                new BsonDocument("_id", id),
                record,
                new ReplaceOptions { IsUpsert = true });
        }
        public async Task DeleteRecordAsync<T>(string table, string id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            await collection.DeleteOneAsync(filter);
        }

        public async Task<PagedList<T>> LoadRecordsWithPagingAsync<T>(string table, int pageSize, int pageNumber)
        {
            var collection = db.GetCollection<T>(table);
            int totalDocuments = (int) await collection.CountDocumentsAsync(new BsonDocument());
            var results = collection.Find(new BsonDocument()).Skip((pageNumber - 1) * pageSize).Limit(pageSize).ToList();

            return new PagedList<T>(results, totalDocuments, pageNumber, pageSize);
            
        }
    }
}
