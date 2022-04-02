using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Pokedex.DataAccess.Models;
using Pokedex.Dto.Response;

namespace Pokedex.Extensions
{
    public static class Mappers
    {
        public static PokedexResponseDto MapTPokedexResponseDto(this PokemonInformation pokemonInformation)
        {
          
            return  new PokedexResponseDto
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
