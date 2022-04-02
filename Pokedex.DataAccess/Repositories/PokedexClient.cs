using Newtonsoft.Json;
using Pokedex.DataAccess.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.DataAccess.Repositories
{
    public class PokedexClient
    {

        public async Task<PokemonInformation> GetPokemonSpecies(string name)
        {
            var url = "https://pokeapi.co/api/v2/pokemon-species/" + name;
            using var httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                PokemonInformation pok = JsonConvert.DeserializeObject<PokemonInformation>(json);
                return pok;
            }

            return null;
        }

    }
}
