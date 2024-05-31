using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace pppk_projekt_Cosmos.DAO
{
    public class CosmosServiceDBProvider
    {

        private const string DatabaseName = "Osobe";
        private const string ContainerName = "Baza Osoba";
        private const string Account= "https://lkrsul.documents.azure.com:443/";
        private const string Key = "EQwnOOFngSIIeUyDpVoJIGX4rz9NSUUSbuzlAa8ABq7OMkWbIM0xy8M8iSBEUhlmDw5psYArc2eUACDbEAXMpg==";

        private static ICosmosDBService cosmosService;

        public static ICosmosDBService CosmosService { get=> cosmosService;  }

        public static async Task Init()
        {
            CosmosClient Client=new CosmosClient(Account,Key);
            cosmosService = new CosmosDBService(Client,DatabaseName,ContainerName);
            DatabaseResponse dbResp=await Client.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await dbResp.Database.CreateContainerIfNotExistsAsync(ContainerName,"/id");
        }
    }
}