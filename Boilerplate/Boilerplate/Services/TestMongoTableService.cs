using System.Collections.Generic;
using System.Threading.Tasks;
using Boilerplate.Data;
using Boilerplate.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Boilerplate.Services
{
    public class TestMongoTableService : ITestMongoTableService
    {
        private IMongoCollection<MongoTable> _testTable;
        private readonly IMongoDbSettings _mongoDbSettings;
        private readonly IMongoClient _mongoClient;

        public TestMongoTableService(IMongoClient mongoClient, IMongoDbSettings mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings;
            _mongoClient = mongoClient;
        }

        public async Task<List<MongoTable>> GetAllAsync(PaginationFilter paginationFilter = null)
        {
            if (paginationFilter == null)
                return await GetCollection().Find(_ => true).ToListAsync();
            
            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            
            var data = await GetCollection().Find(_ => true)
                .Skip(skip)
                .Limit(paginationFilter.PageSize)
                .ToListAsync();

            return data;
        }

        public async Task<MongoTable> GetAsync(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<MongoTable>.Filter.Eq(c => c.Id, objectId);
            var data = await GetCollection().Find(filter).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> CreateAsync(MongoTable data)
        {
            await GetCollection().InsertOneAsync(data);
            return true;
        }

        public async Task<bool> UpdateAsync(MongoTable data)
        {
            var filter = Builders<MongoTable>.Filter.Eq(c => c.Id, data.Id);
            var update = Builders<MongoTable>.Update
                .Set(c => c.Email, data.Email)
                .Set(c => c.Name, data.Name);
            
            var updated = await GetCollection().UpdateOneAsync(filter, update);
            return updated.MatchedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<MongoTable>.Filter.Eq(c => c.Id, objectId);
            var data = await GetCollection().DeleteOneAsync(filter);
            return data.DeletedCount > 0;
        }

        private IMongoCollection<MongoTable> GetCollection()
        {
            if (_testTable is not null)
                return _testTable;
            
            var database = _mongoClient.GetDatabase(_mongoDbSettings.Database);
            var collection = database.GetCollection<MongoTable>(nameof(MongoTable));
        
            _testTable = collection;
            
            return collection;
        }
    }
}