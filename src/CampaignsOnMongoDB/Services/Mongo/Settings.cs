using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignsOnMongoDB.Services.Mongo
{
    public class Settings
    {
        public Settings()
        {
            MongoConnection = "mongodb://localhost:27017";
            Database = "Airtricity";
        }
        public string Database { get; set; }
        public string MongoConnection { get; set; }
    }
}
