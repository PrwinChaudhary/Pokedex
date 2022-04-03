using Pokedex.DataAccess.Models;
using Pokedex.Dto.Response;
using System.Linq;

namespace Pokedex.Extensions
{
    public static class Mappers
    {
        public static PokedexResponseDto MapToResponseDto(this PokemonInformation pokemonInformation)
        {
            return new PokedexResponseDto
            {
                Name = pokemonInformation.Name,
                IsLegendary = pokemonInformation.IsLegendary,
                Habitat = pokemonInformation.Habitat?.Name,
                Description = pokemonInformation.Descriptions?.FirstOrDefault(x => x.Language?.Name == "en")
                    ?.Description
            };
        }
    }
}
