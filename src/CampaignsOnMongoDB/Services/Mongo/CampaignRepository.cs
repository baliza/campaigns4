using CampaignsOnMongoDB.Models;
using Microsoft.Extensions.OptionsModel;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CampaignsOnMongoDB.Services.Mongo
{
    public class CampaignRepository : ICampaignRespository
    {
        private const string CollectionName = "campaigns";
        private readonly IMongoDatabase _database;
        private readonly Settings _settings;

        public CampaignRepository(IOptions<Settings> settings)
        {
            _settings = settings.Value;
            _database = Connect();
        }

        private IMongoDatabase Connect()
        {
            var client = new MongoClient(_settings.MongoConnection);
            var database = client.GetDatabase(_settings.Database);
            return database;
        }

        public IEnumerable<Campaign> AllCampaigns()
        {
            var collection = _database.GetCollection<Campaign>(CollectionName);
            var campaigns = collection.Find(new BsonDocument()).ToListAsync();
            return campaigns.Result;
        }

        public Campaign GetById(ObjectId id)
        {
            var query = Builders<Campaign>.Filter.Eq(e => e.Id, id);
            var campaign = _database.GetCollection<Campaign>(CollectionName).Find(query).ToListAsync();

            return campaign.Result.FirstOrDefault();
        }

        public void Add(Campaign campaign)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Campaign campaign)
        {
            var filter = Builders<Campaign>.Filter.Eq(e => e.Id, campaign.Id);
            _database.GetCollection<Campaign>(CollectionName).ReplaceOneAsync(filter, campaign);
        }

        public bool Remove(ObjectId id)
        {
            throw new System.NotImplementedException();
        }
    }
}