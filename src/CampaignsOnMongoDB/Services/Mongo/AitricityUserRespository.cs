using CampaignsOnMongoDB.Models;
using Microsoft.Extensions.OptionsModel;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace CampaignsOnMongoDB.Services.Mongo
{
    public class AitricityUserRespository : IAitricityUserRespository
    {
        private const string CollectionName = "users";
        private readonly IMongoDatabase _database;
        private readonly Settings _settings;

        public AitricityUserRespository(IOptions<Settings> settings)
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

        private string EncriptPass(string pass)
        {
            return pass;
        }

        public AirtricityUser GetById(ObjectId id)
        {
            throw new System.NotImplementedException();
        }

        public Task<AirtricityUser> ValidateUser(string userEmail, string password)
        {
            return Task.Run(() =>
            {
                var collection = _database.GetCollection<AirtricityUser>(CollectionName);
                  var filter = Builders<AirtricityUser>.Filter.Eq(e => e.Email, userEmail);

                var airtricityUser = collection.Find(filter).ToListAsync();

                  var userF = airtricityUser.Result.FirstOrDefault();
                  var isValid = (userF?.Password == EncriptPass(password));
                  if (!isValid) return null;

                  userF.Password = "";

                
                  
                  return userF;
              });
        }
    }
}