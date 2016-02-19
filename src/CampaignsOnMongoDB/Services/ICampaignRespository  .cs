using CampaignsOnMongoDB.Models;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CampaignsOnMongoDB.Services
{
    public interface ICampaignRespository
    {
        IEnumerable<Campaign> AllCampaigns();

        Campaign GetById(ObjectId id);

        void Add(Campaign campaign);

        void Update(Campaign campaign);

        bool Remove(ObjectId id);
    }
}