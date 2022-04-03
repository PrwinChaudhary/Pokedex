using Pokedex.Services.Response;

namespace Pokedex.Services.Repositories.Interfaces
{
    public  interface IPokemonService
    {
        PokedexResponseDto GetAllPokemonInformation(string name);
        PokedexResponseDto GetPokemonDataWithTranslation(string name);
    }
}
