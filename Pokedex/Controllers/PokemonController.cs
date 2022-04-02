using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.DataAccess.Repositories;
using Pokedex.Dto.Response;
using Pokedex.Extensions;
using System;
using Pokedex.DataAccess.Repositories.Interfaces;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonSpecies _pokemonSpecies;

        public PokemonController(IPokemonSpecies pokemonSpecies)
        {
           _pokemonSpecies = pokemonSpecies;

        }

        [HttpGet("{name}")]
       
        public ObjectResult Get(string name)
        {
            var pokemonResult = _pokemonSpecies.GetAllPokemonInformation(name);
            if (pokemonResult == null)
            {
                return new NotFoundObjectResult($"No Data Found for {name}");
            }

            return new ObjectResult(pokemonResult.MapTPokedexResponseDto());
        }
    }
}
