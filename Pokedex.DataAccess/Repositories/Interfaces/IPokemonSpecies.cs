using Pokedex.DataAccess.Models;

namespace Pokedex.DataAccess.Repositories.Interfaces
{
  public  interface IPokemonSpecies
    {
         PokemonInformation GetAllPokemonInformation(string name);
    }
}
