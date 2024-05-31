using pppk_projekt_Cosmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pppk_projekt_Cosmos.DAO
{
    public interface ICosmosDBService
    {
        Task <IEnumerable<Osoba>> GetOsobeAsync(string query);
        Task<Osoba> GetOsobaAsync(string ID);

        Task AddOsobaAsync(Osoba osoba);
        Task EditOsobaAsync(Osoba osoba);
        Task DeleteOsobaAsync(Osoba osoba);
    }
}
