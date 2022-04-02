using Pokedex.DataAccess.Models;
using Pokedex.DataAccess.Repositories.Interfaces;

namespace Pokedex.DataAccess.Repositories
{
    public class PokemonSpecies : IPokemonSpecies
    {
        public PokemonInformation GetAllPokemonInformation(string name)
        {
            PokedexClient client = new PokedexClient();
            return client.GetPokemonSpecies(name).Result;
        }
    }
}
