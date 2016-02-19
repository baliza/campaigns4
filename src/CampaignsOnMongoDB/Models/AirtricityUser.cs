using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CampaignsOnMongoDB.Models
{
    public class AirtricityUser
    {
        public ObjectId Id { get; set; }

        [BsonElement("UserName")]
        public virtual string UserName { get; set; }
        
        [BsonElement("Password")]
        public virtual string Password { get; set; }

        [BsonElement("Email")]
        public virtual string Email { get; set; }
        

        [BsonElement("Role")]
        public virtual string Role { get; set; }
    }
}
