using Pokedex.DataAccess.Models;
using System.Threading.Tasks;

namespace Pokedex.DataAccess.Repositories.Interfaces
{
    public interface IPokeApiClientRepository
    {
        Task<PokemonInformation> GetPokemonBasicData(string name);
    }
}
