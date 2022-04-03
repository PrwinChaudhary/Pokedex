using Pokedex.Dto.Response;

namespace Pokedex.Services.Repositories.Interfaces
{
    public  interface IPokemonService
    {
        PokedexResponseDto GetAllPokemonInformation(string name);
        PokedexResponseDto GetPokemonDataWithTranslation(string name);
    }
}
