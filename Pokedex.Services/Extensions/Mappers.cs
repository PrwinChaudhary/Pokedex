using Pokedex.DataAccess.Models;
using Pokedex.Services.Response;
using System.Linq;

namespace Pokedex.Extensions
{
    public static class Mappers
    {
        /// <summary>
        /// Map API response to our Custom Required response 
        /// </summary>
        /// <param name="pokemonInformation"></param>
        /// <returns></returns>
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
