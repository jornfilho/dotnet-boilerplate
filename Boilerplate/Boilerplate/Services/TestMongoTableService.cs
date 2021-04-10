using System.Collections.Generic;
using System.Threading.Tasks;
using Boilerplate.Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Boilerplate.Services
{
    public class TestMongoTableService : ITestMongoTableService
    {
        private readonly IMongoCollection<MongoTable> _testMongo;

        public TestMongoTableService(IMongoClient dataContext, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;
            var database = dataContext.GetDatabase(databaseName);
            
            _testMongo = database.GetCollection<MongoTable>(nameof(MongoTable));
        }

        public async Task<List<MongoTable>> GetAllAsync(PaginationFilter paginationFilter = null)
        {
            if (paginationFilter == null)
                return await _testMongo.Find(_ => true).ToListAsync();
            
            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            
            var data = await _testMongo.Find(_ => true)
                .Skip(skip)
                .Limit(paginationFilter.PageSize)
                .ToListAsync();

            return data;
        }

        public async Task<MongoTable> GetAsync(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<MongoTable>.Filter.Eq(c => c.Id, objectId);
            var data = await _testMongo.Find(filter).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> CreateAsync(MongoTable data)
        {
            await _testMongo.InsertOneAsync(data);
            return true;
        }

        public async Task<bool> UpdateAsync(MongoTable data)
        {
            var filter = Builders<MongoTable>.Filter.Eq(c => c.Id, data.Id);
            var update = Builders<MongoTable>.Update
                .Set(c => c.Email, data.Email)
                .Set(c => c.Name, data.Name);
            
            var updated = await _testMongo.UpdateOneAsync(filter, update);
            return updated.MatchedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<MongoTable>.Filter.Eq(c => c.Id, objectId);
            var data = await _testMongo.DeleteOneAsync(filter);
            return data.DeletedCount > 0;
        }
    }
}