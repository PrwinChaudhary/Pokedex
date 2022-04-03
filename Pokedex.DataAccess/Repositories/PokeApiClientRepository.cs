using Pokedex.Client.Utils;
using Pokedex.DataAccess.Models;
using Pokedex.DataAccess.Repositories.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.DataAccess.Repositories
{
    public class PokeApiClientRepository : BaseClientRepository, IPokeApiClientRepository
    {
        public async Task<PokemonInformation> GetPokemonBasicData(string name)
        {
            var url = ApplicationConfig.PokeApiUrl + name;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

            return await SendRequest<PokemonInformation>(request);
        }

    }
}
