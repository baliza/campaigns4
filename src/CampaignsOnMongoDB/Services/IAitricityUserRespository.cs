using CampaignsOnMongoDB.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace CampaignsOnMongoDB.Services
{
    public interface IAitricityUserRespository
    {        
        AirtricityUser GetById(ObjectId id);
        Task<AirtricityUser> ValidateUser(string userEmail, string password);

    }
}