using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CampaignsOnMongoDB.Models
{
//    public abstract class Preference
//{
//        public ObjectId Id { get; set; }
//    }

//    public class PreferencesC1234:Preference
//    {
//        public List<string> Sizes;
//        public List<string> Colors;


//    }
//    public class PreferencesC9876 : Preference
//    {
//        public List<int> Reductions;        

//    }

        //http://www.drdobbs.com/database/mongodb-with-c-deep-dive/240152181
    public class Campaign
    {
        public ObjectId Id { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("StartDate")]
        public string StartDate { get; set; }

        [BsonElement("EndDate")]
        public string EndDate { get; set; }

        [BsonElement("Amount")]
        public int Amount { get; set; }

        //[BsonElement("Preferences")]
        //public Preference Preference { get; set; }
        

        [BsonElement("WhitListedUsers")]
        public IEnumerable<WhitListedUser> WhitListedUsers { get; set; }
    }

    public class WhitListedUser
    {
        public ObjectId Id { get; set; }

        [BsonElement("AccountId")]
        public string AccountId { get; set; }

        [BsonElement("Voucher")]
        public string Voucher { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("RequestedOn")]
        public DateTime RequestedOn { get; set; }
    }
}