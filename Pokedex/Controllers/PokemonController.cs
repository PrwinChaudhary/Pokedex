using Microsoft.AspNetCore.Mvc;
using Pokedex.Services.Repositories.Interfaces;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonSpecies)
        {
            _pokemonService = pokemonSpecies;

        }

        /// <summary>
        /// Get Pokemon Basic Information(Name, Description, Habitat, IsLegendary) by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]

        public ObjectResult Get(string name)
        {
            var pokemonResult = _pokemonService.GetAllPokemonInformation(name);
            if (pokemonResult == null)
            {
                return new NotFoundObjectResult($"No Data Found for {name}");
            }

            return new ObjectResult(pokemonResult);
        }

        /// <summary>
        /// Get Pokemon Basic Information(Name, Description, Habitat, IsLegendary) with Fun Translation of description by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("translated/{name}")]

        public ObjectResult GetTranslatedPokemon(string name)
        {
            var pokemonResult = _pokemonService.GetPokemonDataWithTranslation(name);
            if (pokemonResult == null)
            {
                return new NotFoundObjectResult($"No Data Found for {name}");
            }

            return new ObjectResult(pokemonResult);
        }
    }
}
