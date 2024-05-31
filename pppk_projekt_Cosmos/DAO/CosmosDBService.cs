using Microsoft.Azure.Cosmos;
using pppk_projekt_Cosmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace pppk_projekt_Cosmos.DAO
{
    public class CosmosDBService : ICosmosDBService
    {
        private readonly Container container;
        public CosmosDBService(CosmosClient client,string DBName,string containerName)
        {
            container = client.GetContainer(DBName,containerName);
        }
        public async Task AddOsobaAsync(Osoba osoba)=>await container.CreateItemAsync(osoba,new PartitionKey(osoba.ID));
        

        public async Task DeleteOsobaAsync(Osoba osoba)=> await container.DeleteItemAsync<Osoba> (osoba.ID,new PartitionKey(osoba.ID));
        


        public async Task EditOsobaAsync(Osoba osoba)=> await container.UpsertItemAsync(osoba,new PartitionKey(osoba.ID));
       

        public async Task<Osoba> GetOsobaAsync(string ID)
        {
            try
            {
                return await container.ReadItemAsync<Osoba>(ID, new PartitionKey(ID));
            }
            catch (CosmosException ex) when(ex.StatusCode!= System.Net.HttpStatusCode.NotFound)
            {

                return null;
            }
        }

        public async Task<IEnumerable<Osoba>> GetOsobeAsync(string queryStr)
        {
            List<Osoba> osobe=new List<Osoba>();
            var query=container.GetItemQueryIterator<Osoba>(new QueryDefinition(queryStr));
            while (query.HasMoreResults)
            {
                var result=await query.ReadNextAsync();
                osobe.AddRange(result.ToList());
            }
            return osobe;
        }
    }
}